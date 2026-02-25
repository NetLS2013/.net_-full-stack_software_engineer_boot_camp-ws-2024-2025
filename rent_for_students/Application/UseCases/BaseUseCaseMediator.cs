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
    /// Concrete mediators inherit from this class and build explicit operation flows
    /// using the shared validation/result/notification helpers below.
    /// </summary>
    public abstract class BaseUseCaseMediator
    {
        protected readonly INotificationService _notificationService;

        protected BaseUseCaseMediator(INotificationService notificationService)
        {
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        /// <summary>
        /// PROMPT v1.1: Pragmatic template-flow helpers - validation failure handling
        /// </summary>
        protected Result<T> ValidationFailure<T>(OperationValidationResult validation)
        {
            if (validation.IsValid)
            {
                throw new ArgumentException("Validation result must be invalid.", nameof(validation));
            }

            string errorCode = string.IsNullOrWhiteSpace(validation.ErrorCode)
                ? ErrorCodes.ValidationError
                : validation.ErrorCode;
            string errorMessage = string.IsNullOrWhiteSpace(validation.ErrorMessage)
                ? "Validation failed."
                : validation.ErrorMessage;

            return Result<T>.Failure(errorCode, errorMessage);
        }

        /// <summary>
        /// PROMPT v1.1: Pragmatic template-flow helpers - success result factory
        /// </summary>
        protected Result<T> Success<T>(T value, string? message = null)
            => Result<T>.Success(value, message);

        /// <summary>
        /// PROMPT v1.1: Pragmatic template-flow helpers - optional notifications
        /// </summary>
        protected async Task NotifyIfNeededAsync(string? notificationMessage, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(notificationMessage))
            {
                return;
            }

            await _notificationService.NotifyAsync(notificationMessage, ct);
        }

        protected static OperationValidationResult Valid()
            => OperationValidationResult.Valid();
    }
}
