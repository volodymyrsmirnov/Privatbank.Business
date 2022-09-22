using System;

namespace Privatbank.Business.Exceptions {
    /// <summary>
    /// API response exception.
    /// </summary>
    public class PrivatbankResponseException : Exception {
        /// <summary>
        /// Create new API response exception.
        /// </summary>
        /// <param name="code">Error code.</param>
        /// <param name="message">Error message.</param>
        public PrivatbankResponseException(string code, string message) : base(message) {
            Code = code;
        }

        /// <summary>
        /// Error code.
        /// </summary>
        public string Code { get; }
    }
}