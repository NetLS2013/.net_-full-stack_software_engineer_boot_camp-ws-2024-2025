using rent_for_students.Application.Common;
using rent_for_students.Application.Notifications;
using rent_for_students.Domain.Entities;
using rent_for_students.Domain.Requests;
using rent_for_students.Domain.Services;

namespace rent_for_students.Application.UseCases
{
    // PROMPT v1.0: Template Method integration - ListingUseCaseMediator
    public class ListingUseCaseMediator : BaseUseCaseMediator, IListingUseCaseMediator
    {
        private readonly HousingService _housingService;

        public ListingUseCaseMediator(HousingService housingService, INotificationService notificationService)
            : base(notificationService)
        {
            _housingService = housingService ?? throw new ArgumentNullException(nameof(housingService));
        }

        public async Task<Result<IReadOnlyList<HousingListing>>> SearchListingsAsync(ListingSearchCriteria criteria, CancellationToken ct = default)
        {
            if (criteria is null)
            {
                return Result<IReadOnlyList<HousingListing>>.Failure(ErrorCodes.ValidationError, "Search criteria is required.");
            }

            var listings = await _housingService.SearchListingsAsync(criteria, ct);
            return Result<IReadOnlyList<HousingListing>>.Success(listings);
        }

        public async Task<Result<HousingListing>> GetDetailsAsync(Guid id, CancellationToken ct = default)
        {
            if (id == Guid.Empty)
            {
                return Result<HousingListing>.Failure(ErrorCodes.ValidationError, "Listing id is invalid.");
            }

            var listing = await _housingService.GetListingDetailsAsync(id, ct);
            if (listing is null)
            {
                return Result<HousingListing>.Failure(ErrorCodes.NotFound, "Listing not found.");
            }

            return Result<HousingListing>.Success(listing);
        }

        // PROMPT v1.0: Template Method refactoring - CreateAsync operation
        public async Task<Result<Guid>> CreateAsync(HousingListing listing, CancellationToken ct = default)
        {
            return await ExecuteOperationAsync(
                input: listing,
                validateAsync: async (input) =>
                {
                    if (input is null)
                        return (false, "Listing is required.", null);
                    
                    var validationMessage = ValidateListing(input);
                    if (validationMessage is not null)
                        return (false, validationMessage, null);
                    
                    return (true, null, null);
                },
                executeAsync: async (input) => await _housingService.CreateListingAsync(input, ct),
                notificationMessage: $"Listing created: {listing.Id}",
                ct: ct
            );
        }

        // PROMPT v1.0: Template Method refactoring - CreateDraftAsync operation
        public async Task<Result<Guid>> CreateDraftAsync(HousingListing draft, CancellationToken ct = default)
        {
            return await ExecuteOperationAsync(
                input: draft,
                validateAsync: async (input) =>
                {
                    if (input is null)
                        return (false, "Draft is required.", null);
                    
                    var validationMessage = ValidateListing(input);
                    if (validationMessage is not null)
                        return (false, validationMessage, null);
                    
                    return (true, null, null);
                },
                executeAsync: async (input) => await _housingService.CreateListingDraftAsync(input, ct),
                notificationMessage: $"Draft created: {draft.Id}",
                ct: ct
            );
        }

        public async Task<Result<bool>> UpdateDraftAsync(Guid id, HousingListing draft, CancellationToken ct = default)
        {
            if (id == Guid.Empty || draft is null)
            {
                return Result<bool>.Failure(ErrorCodes.ValidationError, "Draft update payload is invalid.");
            }

            var validationMessage = ValidateListing(draft);
            if (validationMessage is not null)
            {
                return Result<bool>.Failure(ErrorCodes.ValidationError, validationMessage);
            }

            var updated = await _housingService.UpdateListingDraftAsync(id, draft, ct);
            if (!updated)
            {
                return Result<bool>.Failure(ErrorCodes.NotFoundOrNotDraft, "Draft listing was not found or is already published.");
            }

            await _notificationService.NotifyAsync($"Draft updated: {id}", ct);
            return Result<bool>.Success(true);
        }

        public async Task<Result<bool>> PublishAsync(Guid id, CancellationToken ct = default)
        {
            if (id == Guid.Empty)
            {
                return Result<bool>.Failure(ErrorCodes.ValidationError, "Listing id is invalid.");
            }

            var published = await _housingService.PublishListingAsync(id, ct);
            if (!published)
            {
                return Result<bool>.Failure(ErrorCodes.NotFound, "Listing was not found.");
            }

            await _notificationService.NotifyAsync($"Listing published: {id}", ct);
            return Result<bool>.Success(true);
        }

        public async Task<Result<bool>> UpdateAsync(Guid id, HousingListing listing, CancellationToken ct = default)
        {
            if (id == Guid.Empty || listing is null)
            {
                return Result<bool>.Failure(ErrorCodes.ValidationError, "Listing update payload is invalid.");
            }

            var validationMessage = ValidateListing(listing);
            if (validationMessage is not null)
            {
                return Result<bool>.Failure(ErrorCodes.ValidationError, validationMessage);
            }

            var updated = await _housingService.UpdateListingAsync(id, listing, ct);
            if (!updated)
            {
                return Result<bool>.Failure(ErrorCodes.NotFound, "Listing was not found.");
            }

            await _notificationService.NotifyAsync($"Listing updated: {id}", ct);
            return Result<bool>.Success(true);
        }

        private static string? ValidateListing(HousingListing listing)
        {
            if (string.IsNullOrWhiteSpace(listing.Title) || listing.Title.Trim().Length < 2)
            {
                return "Title is required and must be at least 2 characters.";
            }

            if (string.IsNullOrWhiteSpace(listing.City))
            {
                return "City is required.";
            }

            if (listing.PricePerMonth <= 0)
            {
                return "Price per month must be greater than 0.";
            }

            if (listing.AreaSqm < 10)
            {
                return "Area must be at least 10 sqm.";
            }

            return null;
        }
    }
}
