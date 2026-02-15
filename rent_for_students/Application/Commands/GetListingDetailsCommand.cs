using rent_for_students.Domain.Services;
using rent_for_students.Domain.Entities;

namespace rent_for_students.Application.Commands
{
    public sealed class GetListingDetailsCommand : ICommand<HousingListing?>
    {
        private readonly HousingService _receiver;
        private readonly Guid _listingId;

        public GetListingDetailsCommand(HousingService receiver, Guid listingId)
        {
            _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
            _listingId = listingId;
        }

        public Task<HousingListing?> ExecuteAsync(CancellationToken ct = default)
            => _receiver.GetListingDetailsAsync(_listingId, ct);
    }

}
