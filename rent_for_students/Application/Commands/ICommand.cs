namespace rent_for_students.Application.Commands
{
    public interface ICommand<TResult>
    {
        Task<TResult> ExecuteAsync(CancellationToken ct = default);
    }
}
