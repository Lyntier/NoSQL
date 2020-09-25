namespace NoSQL.UI.ViewModels
{
    /// <summary>
    /// Displays developer errors when present in the web application.
    /// </summary>
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
