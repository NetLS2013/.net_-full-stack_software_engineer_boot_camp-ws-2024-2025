using rent_for_students.Application.Common;
using rent_for_students.Application.Notifications;
using rent_for_students.Domain.Contracts;
using rent_for_students.Domain.Entities;
using rent_for_students.Domain.Services;

namespace rent_for_students.Application.UseCases
{
    // PROMPT v1.0: Template Method integration - ApplicationUseCaseMediator
    public class ApplicationUseCaseMediator : BaseUseCaseMediator, IApplicationUseCaseMediator
    {
        private readonly HousingService _housingService;
        private readonly IRentalApplicationRepository _rentalApplicationRepository;

        public ApplicationUseCaseMediator(
            HousingService housingService,
            IRentalApplicationRepository rentalApplicationRepository,
            INotificationService notificationService)
            : base(notificationService)
        {
            _housingService = housingService ?? throw new ArgumentNullException(nameof(housingService));
            _rentalApplicationRepository = rentalApplicationRepository ?? throw new ArgumentNullException(nameof(rentalApplicationRepository));
        }

        // PROMPT v1.0: Template Method refactoring - ApplyAsync operation
        public async Task<Result<Guid>> ApplyAsync(Guid listingId, RentalApplication applicant, CancellationToken ct = default)
        {
            return await ExecuteOperationAsync(
                input: (listingId, applicant),
                validateAsync: async (input) =>
                {
                    var (lId, app) = input;
                    if (lId == Guid.Empty || app is null)
                        return (false, "Application payload is invalid.", ErrorCodes.ValidationError);
                    
                    var validationMessage = ValidateApplicant(app);
                    if (validationMessage is not null)
                        return (false, validationMessage, ErrorCodes.ValidationError);
                    
                    var listing = await _housingService.GetListingDetailsAsync(lId, ct);
                    if (listing is null || !listing.IsActive)
                        return (false, "Listing not found or not published.", ErrorCodes.ListingNotAvailable);
                    
                    return (true, null, null);
                },
                executeAsync: async (input) =>
                {
                    var (lId, app) = input;
                    
                    app.Id = app.Id == Guid.Empty ? Guid.NewGuid() : app.Id;
                    app.ListingId = lId;
                    app.CreatedAtUtc = app.CreatedAtUtc == default ? DateTime.UtcNow : app.CreatedAtUtc;
                    app.Approve();

                    await _rentalApplicationRepository.AddAsync(app, ct);
                    await _rentalApplicationRepository.SaveChangesAsync(ct);

                    return app.Id;
                },
                notificationMessage: $"Rental application created: applicationId={applicant.Id}, listingId={listingId}, status={applicant.Status}",
                ct: ct
            );
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
