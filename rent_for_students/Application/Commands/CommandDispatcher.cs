namespace rent_for_students.Application.Commands
{
    public class CommandDispatcher
    {
        public async Task<TResult> DispatchAsync<TResult>(ICommand<TResult> command, CancellationToken ct = default)
        {
            if (command is null) throw new ArgumentNullException(nameof(command));

            return await command.ExecuteAsync(ct);
        }
    }
}
