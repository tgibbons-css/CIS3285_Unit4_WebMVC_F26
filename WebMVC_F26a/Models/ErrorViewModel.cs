namespace WebMVC_F26a.Models;

// Supplies request information to the error view without exposing exception details to the user.
public class ErrorViewModel
{
    // Request identifier can help correlate the displayed error with server-side diagnostics.
    public string? RequestId { get; set; }

    // The view uses this to decide whether there is an id worth displaying.
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
