using rent_for_students.Application.Common;
using rent_for_students.Application.Notifications;
using rent_for_students.Domain.Contracts;
using rent_for_students.Domain.Entities;
using rent_for_students.Domain.Services;

namespace rent_for_students.Application.UseCases
{
    public class ApplicationUseCaseMediator : IApplicationUseCaseMediator
    {
        private readonly HousingService _housingService;
        private readonly IRentalApplicationRepository _rentalApplicationRepository;
        private readonly INotificationService _notificationService;

        public ApplicationUseCaseMediator(
            HousingService housingService,
            IRentalApplicationRepository rentalApplicationRepository,
            INotificationService notificationService)
        {
            _housingService = housingService;
            _rentalApplicationRepository = rentalApplicationRepository;
            _notificationService = notificationService;
        }

        public async Task<Result<Guid>> ApplyAsync(Guid listingId, RentalApplication applicant, CancellationToken ct = default)
        {
            if (listingId == Guid.Empty || applicant is null)
            {
                return Result<Guid>.Failure(ErrorCodes.ValidationError, "Application payload is invalid.");
            }

            var validationMessage = ValidateApplicant(applicant);
            if (validationMessage is not null)
            {
                return Result<Guid>.Failure(ErrorCodes.ValidationError, validationMessage);
            }

            var listing = await _housingService.GetListingDetailsAsync(listingId, ct);
            if (listing is null || !listing.IsActive)
            {
                return Result<Guid>.Failure(ErrorCodes.ListingNotAvailable, "Listing not found or not published.");
            }

            applicant.Id = applicant.Id == Guid.Empty ? Guid.NewGuid() : applicant.Id;
            applicant.ListingId = listingId;
            applicant.CreatedAtUtc = applicant.CreatedAtUtc == default ? DateTime.UtcNow : applicant.CreatedAtUtc;
            applicant.Approve();

            await _rentalApplicationRepository.AddAsync(applicant, ct);
            await _rentalApplicationRepository.SaveChangesAsync(ct);

            await _notificationService.NotifyAsync(
                $"Rental application created: applicationId={applicant.Id}, listingId={listingId}, status={applicant.Status}",
                ct);

            return Result<Guid>.Success(applicant.Id, "Rental application was created.");
        }

        public async Task<Result<IReadOnlyList<RentalApplication>>> ListByListingIdAsync(Guid listingId, CancellationToken ct = default)
        {
            if (listingId == Guid.Empty)
            {
                return Result<IReadOnlyList<RentalApplication>>.Failure(ErrorCodes.ValidationError, "Listing id is invalid.");
            }

            var listing = await _housingService.GetListingDetailsAsync(listingId, ct);
            if (listing is null)
            {
                return Result<IReadOnlyList<RentalApplication>>.Failure(ErrorCodes.NotFound, "Listing not found.");
            }

            var applications = await _rentalApplicationRepository.ListByListingIdAsync(listingId, ct);
            return Result<IReadOnlyList<RentalApplication>>.Success(applications);
        }

        private static string? ValidateApplicant(RentalApplication applicant)
        {
            if (string.IsNullOrWhiteSpace(applicant.ApplicantName))
            {
                return "Applicant name is required.";
            }

            if (string.IsNullOrWhiteSpace(applicant.Phone))
            {
                return "Phone is required.";
            }

            if (string.IsNullOrWhiteSpace(applicant.Email) || !applicant.Email.Contains('@'))
            {
                return "Valid email is required.";
            }

            return null;
        }
    }
}
