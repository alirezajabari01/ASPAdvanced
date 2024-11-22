using System.Net;

namespace Shop.EndPoint.API.Exceptions
{
    public class DontAllowAccessException : ApplicationException
    {
        //public DontAllowAccessException() : base("dont Access to this Resource", HttpStatusCode.Unauthorized, true)
        //{
        //}

        public DontAllowAccessException() : base(Resource.ApplicationExceptionMessage, HttpStatusCode.Unauthorized, false)
        {
        }
    }

}
