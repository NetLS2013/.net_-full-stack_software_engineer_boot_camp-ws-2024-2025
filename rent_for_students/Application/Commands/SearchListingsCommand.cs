using rent_for_students.Domain.Requests;
using rent_for_students.Domain.Services;
using rent_for_students.Domain.Entities;

namespace rent_for_students.Application.Commands
{
    public sealed class SearchListingsCommand : ICommand<IReadOnlyList<HousingListing>>
    {
        private readonly HousingService _receiver;
        private readonly ListingSearchCriteria _criteria;

        public SearchListingsCommand(HousingService receiver, ListingSearchCriteria criteria)
        {
            _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
            _criteria = criteria ?? throw new ArgumentNullException(nameof(criteria));
        }

        public Task<IReadOnlyList<HousingListing>> ExecuteAsync(CancellationToken ct = default)
            => _receiver.SearchListingsAsync(_criteria, ct);
    }
}
