using rent_for_students.Application.Common;
using rent_for_students.Application.UseCases;
using rent_for_students.Domain.Entities;

namespace rent_for_students.Application.Commands
{
    // PROMPT v1.3: Prototype source management command.
    public sealed class CreateRentalApplicationProfileCommand : ICommand<Guid>
    {
        private readonly IApplicationUseCaseMediator _receiver;
        private readonly RentalApplicationProfile _profile;

        public CreateRentalApplicationProfileCommand(IApplicationUseCaseMediator receiver, RentalApplicationProfile profile)
        {
            _receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
            _profile = profile ?? throw new ArgumentNullException(nameof(profile));
        }

        public Task<Result<Guid>> ExecuteAsync(CancellationToken ct = default)
            => _receiver.CreateProfileAsync(_profile, ct);
    }
}
