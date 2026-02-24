using rent_for_students.Application.Common;
using rent_for_students.Application.Notifications;

namespace rent_for_students.Application.UseCases
{
    /// <summary>
    /// PROMPT v1.0: Template Method integration - BaseUseCaseMediator
    /// 
    /// Base class that implements the Template Method pattern for use case operations.
    /// Defines the standard flow: Validate → Execute → Notify → Return Result
    /// 
    /// Concrete mediators inherit from this class and provide:
    /// - validateAsync: Func to validate input and return error message or code
    /// - executeAsync: Func to execute the operation
    /// - notificationMessage: Optional message for notification
    /// </summary>
    public abstract class BaseUseCaseMediator
    {
        protected readonly INotificationService _notificationService;

        protected BaseUseCaseMediator(INotificationService notificationService)
        {
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        /// <summary>
        /// PROMPT v1.0: Template Method pattern - ExecuteOperationAsync
        /// 
        /// Defines the standard operation flow:
        /// 1. Validate (using provided delegate)
        /// 2. Execute (using provided delegate)
        /// 3. Notify (optional, if notificationMessage is provided)
        /// 4. Return Result
        /// 
        /// This method eliminates code duplication across all CRUD operations.
        /// Each operation only needs to provide custom validation and execution logic via delegates.
        /// </summary>
        protected async Task<Result<TOutput>> ExecuteOperationAsync<TInput, TOutput>(
            TInput input,
            Func<TInput, Task<(bool IsValid, string? ErrorMessage)>> validateAsync,
            Func<TInput, Task<TOutput>> executeAsync,
            string? notificationMessage = null,
            CancellationToken ct = default)
        {
            if (validateAsync is null)
                throw new ArgumentNullException(nameof(validateAsync));
            if (executeAsync is null)
                throw new ArgumentNullException(nameof(executeAsync));

            // Phase 1: Validate
            var (isValid, errorMessage) = await validateAsync(input);
            if (!isValid && errorMessage is not null)
            {
                return Result<TOutput>.Failure(ErrorCodes.ValidationError, errorMessage);
            }

            // Phase 2: Execute
            var result = await executeAsync(input);

            // Phase 3: Notify (optional)
            if (!string.IsNullOrEmpty(notificationMessage))
            {
                await _notificationService.NotifyAsync(notificationMessage, ct);
            }

            // Phase 4: Return
            return Result<TOutput>.Success(result);
        }

        /// <summary>
        /// Overload for operations that need custom error codes
        /// </summary>
        protected async Task<Result<TOutput>> ExecuteOperationAsync<TInput, TOutput>(
            TInput input,
            Func<TInput, Task<(bool IsValid, string? ErrorMessage, string? ErrorCode)>> validateAsync,
            Func<TInput, Task<TOutput>> executeAsync,
            string? notificationMessage = null,
            CancellationToken ct = default)
        {
            if (validateAsync is null)
                throw new ArgumentNullException(nameof(validateAsync));
            if (executeAsync is null)
                throw new ArgumentNullException(nameof(executeAsync));

            // Phase 1: Validate
            var (isValid, errorMessage, errorCode) = await validateAsync(input);
            if (!isValid && errorMessage is not null)
            {
                var code = errorCode ?? ErrorCodes.ValidationError;
                return Result<TOutput>.Failure(code, errorMessage);
            }

            // Phase 2: Execute
            var result = await executeAsync(input);

            // Phase 3: Notify (optional)
            if (!string.IsNullOrEmpty(notificationMessage))
            {
                await _notificationService.NotifyAsync(notificationMessage, ct);
            }

            // Phase 4: Return
            return Result<TOutput>.Success(result);
        }
    }
}
