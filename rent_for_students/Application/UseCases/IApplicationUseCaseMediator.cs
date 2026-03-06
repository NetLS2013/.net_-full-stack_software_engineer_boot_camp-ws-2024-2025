using rent_for_students.Application.Common;
using rent_for_students.Domain.Entities;

namespace rent_for_students.Application.UseCases
{
    public interface IApplicationUseCaseMediator
    {
        Task<Result<Guid>> ApplyAsync(Guid listingId, RentalApplication applicant, CancellationToken ct = default);
        Task<Result<Guid>> ApplyFromProfileAsync(Guid listingId, Guid profileId, CancellationToken ct = default);
        Task<Result<Guid>> CreateProfileAsync(RentalApplicationProfile profile, CancellationToken ct = default);
        Task<Result<IReadOnlyList<RentalApplicationProfile>>> ListProfilesAsync(CancellationToken ct = default);
        Task<Result<IReadOnlyList<RentalApplication>>> ListByListingIdAsync(Guid listingId, CancellationToken ct = default);
    }
}
