using System.Net;
using System.Net.Http;

namespace Carsales.Common.Exception
{
    public static class ApiControllerExtension
    {
        public static ApiExceptionActionResult ApiException(HttpRequestMessage request, HttpStatusCode statusCode, string message)
        {
            return new ApiExceptionActionResult(request, statusCode, message);
        }
    }
}
