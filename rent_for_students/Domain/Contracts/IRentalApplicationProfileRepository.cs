using rent_for_students.Domain.Entities;

namespace rent_for_students.Domain.Contracts
{
    public interface IRentalApplicationProfileRepository
    {
        Task AddAsync(RentalApplicationProfile profile, CancellationToken ct = default);
        Task<RentalApplicationProfile?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<IReadOnlyList<RentalApplicationProfile>> ListAsync(CancellationToken ct = default);
        Task SaveChangesAsync(CancellationToken ct = default);
    }
}
