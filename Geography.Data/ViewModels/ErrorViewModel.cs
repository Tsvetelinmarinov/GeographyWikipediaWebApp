namespace Geography.Data.ViewModels
{
    /// <summary>
    /// Supplies request-tracing information to the shared error page.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>Identifier used to trace the failed HTTP request.</summary>
        public string? RequestId { get; set; }

        /// <summary>Indicates whether a request identifier is available for display.</summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}