using rent_for_students.Domain.Contracts;
using rent_for_students.Domain.Entities;

namespace rent_for_students.Tests.TestDoubles
{
    internal sealed class InMemoryRentalApplicationProfileRepository : IRentalApplicationProfileRepository
    {
        private readonly List<RentalApplicationProfile> _items = new();

        public Task AddAsync(RentalApplicationProfile profile, CancellationToken ct = default)
        {
            _items.Add(profile);
            return Task.CompletedTask;
        }

        public Task<RentalApplicationProfile?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => Task.FromResult(_items.FirstOrDefault(x => x.Id == id));

        public Task<IReadOnlyList<RentalApplicationProfile>> ListAsync(CancellationToken ct = default)
            => Task.FromResult<IReadOnlyList<RentalApplicationProfile>>(
                _items.OrderBy(x => x.ProfileName).ThenByDescending(x => x.UpdatedAtUtc).ToList());

        public Task SaveChangesAsync(CancellationToken ct = default) => Task.CompletedTask;
    }
}
