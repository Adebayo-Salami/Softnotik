namespace Softnotik.UI.Shared.Models
{
    public sealed record LogMessage(string LogLevel, string Source, string ExceptionMessage, string StackTrace, string CreatedDate);
}
