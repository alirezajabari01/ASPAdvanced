using System.Net;

namespace Shop.EndPoint.API.Exceptions
{
    public class TestException : ApplicationException
    {
        public TestException() : base("Test", HttpStatusCode.BadGateway, false)
        {

        }
    }

}
