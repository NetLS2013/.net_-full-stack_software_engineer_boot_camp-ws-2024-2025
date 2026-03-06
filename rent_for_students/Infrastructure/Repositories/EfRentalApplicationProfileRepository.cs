using Microsoft.EntityFrameworkCore;
using rent_for_students.Domain.Contracts;
using rent_for_students.Domain.Entities;
using rent_for_students.Infrastructure.Data;

namespace rent_for_students.Infrastructure.Repositories
{
    public class EfRentalApplicationProfileRepository : IRentalApplicationProfileRepository
    {
        private readonly AppDbContext _db;

        public EfRentalApplicationProfileRepository(AppDbContext db)
        {
            _db = db;
        }

        public Task AddAsync(RentalApplicationProfile profile, CancellationToken ct = default)
            => _db.RentalApplicationProfiles.AddAsync(profile, ct).AsTask();

        public Task<RentalApplicationProfile?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => _db.RentalApplicationProfiles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);

        public async Task<IReadOnlyList<RentalApplicationProfile>> ListAsync(CancellationToken ct = default)
            => await _db.RentalApplicationProfiles
                .AsNoTracking()
                .OrderBy(x => x.ProfileName)
                .ThenByDescending(x => x.UpdatedAtUtc)
                .ToListAsync(ct);

        public Task SaveChangesAsync(CancellationToken ct = default)
            => _db.SaveChangesAsync(ct);
    }
}
