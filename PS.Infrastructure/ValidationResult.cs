
namespace PS.Infrastructure
{
    /// <summary>
    /// Describes the result of a validation of a potential change through a business service.
    /// </summary>
    public class ValidationResult
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> class.
        /// </summary>
        public ValidationResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> class.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        /// <param name="message">The message.</param>
        public ValidationResult(string errorCode, string message)
        {
            this.ErrorCode = errorCode;
            this.Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ValidationResult(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>
        /// Error code.
        /// </value>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static ValidationResult Success
        {
            get
            {
                return null;
            }
        }
    }
}
