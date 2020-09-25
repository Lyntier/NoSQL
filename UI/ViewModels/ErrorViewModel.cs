// ReSharper disable once InvalidXmlDocComment
/// <summary> Contains all view models used in the UI project to display data in a user-friendly format. </summary>
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
