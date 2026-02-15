using rent_for_students.Domain.Services;
using rent_for_students.Domain.Entities;

namespace rent_for_students.Application.Commands
{
    public sealed class CreateListingCommand : ICommand<Guid>
    {
        private readonly HousingService _receiver;
        private readonly HousingListing _listing;

        public CreateListingCommand(HousingService receiver, HousingListing listing)
        {
            _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
            _listing = listing ?? throw new ArgumentNullException(nameof(listing));
        }

        public Task<Guid> ExecuteAsync(CancellationToken ct = default)
            => _receiver.CreateListingAsync(_listing, ct);
    }
}
