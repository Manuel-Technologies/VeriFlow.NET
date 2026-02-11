using System;
using System.Threading;
using System.Threading.Tasks;

namespace VeriFlow.Core
{
    /// <summary>
    /// Represents the result of an OTP generation and sending operation.
    /// </summary>
    public class OtpResult
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
    }

    /// <summary>
    /// Represents the result of an OTP verification operation.
    /// </summary>
    public class VerificationResult
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
    }

    /// <summary>
    /// The primary service for generating and verifying one-time passcodes.
    /// </summary>
    public interface IVeriFlowService
    {
        /// <summary>
        /// Generates an OTP, stores it, and sends it to the user via a configured email provider.
        /// </summary>
        /// <param name="email">The recipient's email address.</param>
        /// <param name="purpose">A unique purpose identifier for the OTP (e.g., "email-verification", "password-reset").</param>
        /// <param name="ct">A cancellation token.</param>
        /// <returns>An <see cref="OtpResult"/> indicating the outcome of the operation.</returns>
        Task<OtpResult> SendEmailAsync(string email, string purpose, CancellationToken ct = default);

        /// <summary>
        /// Verifies an OTP provided by the user against the stored value.
        /// </summary>
        /// <param name="identifier">The identifier used when sending the OTP (e.g., the user's email address).</param>
        /// <param name="code">The OTP code provided by the user.</param>
        /// <param name="ct">A cancellation token.</param>
        /// <returns>A <see cref="VerificationResult"/> indicating whether the code is valid.</returns>
        Task<VerificationResult> VerifyAsync(string identifier, string code, CancellationToken ct = default);
    }
}
