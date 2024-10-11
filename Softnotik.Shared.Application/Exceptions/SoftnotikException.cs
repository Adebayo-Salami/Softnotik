using Softnotik.Shared.Domain;

namespace Softnotik.Shared.Application.Exceptions
{
    public sealed class SoftnotikException : Exception
    {
        public SoftnotikException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
        {
            RequestName = requestName;
            Error = error;
        }

        public string RequestName { get; }
        public Error? Error { get; }
    }
}
