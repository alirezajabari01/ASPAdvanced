using System.Net;

namespace Shop.EndPoint.API.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message, HttpStatusCode statusCode, bool isConfidentiality) : base(message)
        {
            StatusCode = statusCode;
            IsConfidentiality = isConfidentiality;
        }

        public HttpStatusCode StatusCode { get; private set; }
        public bool IsConfidentiality { get; private set; }
    }

}
