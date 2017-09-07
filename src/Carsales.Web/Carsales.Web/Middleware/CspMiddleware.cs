using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using Carsales.Web;
using Microsoft.AspNetCore.Builder;

namespace Carsales.Web.Middleware
{
    public class CspMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        public CspMiddleware(RequestDelegate next, IOptionsSnapshot<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }
        
        private string GetCspValue()
        {
            var coachingApiHost = new Uri(_appSettings.ApiUrl);

            var defaultSrc = "'self'";
            var scriptSrc = $"'self' 'unsafe-inline' https://cdnjs.cloudflare.com https://carsalesweb.azurewebsites.net {_appSettings.ApiUrl}";
            var styleSrc = "'self' 'unsafe-inline' https://cdnjs.cloudflare.com https://carsalesweb.azurewebsites.net";
            var fontSrc = "'self' https://cdnjs.cloudflare.com http://fonts.gstatic.com https://fonts.gstatic.com https://carsalesweb.azurewebsites.net";
            var connectSrc = $"'self' https://dc.services.visualstudio.com {_appSettings.ApiUrl}";
            var imgSrc = "'self' https://carsalesweb.azurewebsites.net https://carsalesapi.azurewebsites.net https://cdnjs.cloudflare.com https://img.youtube.com";
            var mediaSrc = "'self' https://carsalesapi.azurewebsites.net";

            var csp = $"default-src {defaultSrc};style-src {styleSrc};script-src {scriptSrc};font-src {fontSrc};connect-src {connectSrc};img-src {imgSrc};object-src 'none';child-src 'none';frame-ancestors 'none';media-src {mediaSrc}";
            
            return csp;
        }
        
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Content-Security-Policy", GetCspValue());
            
            await _next.Invoke(httpContext);
        }
    }
    
    public static class CspMiddlewareExtensions
    {
        public static IApplicationBuilder UseCsp(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CspMiddleware>();
        }
    }
}