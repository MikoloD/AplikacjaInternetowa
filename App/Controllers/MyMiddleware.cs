using App.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class MyMiddleware
    {
        private ApplicationDbContext _dbContext;
        private readonly RequestDelegate _next;
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ApplicationDbContext dbContext)
        {
            // Do something with context near the beginning of request processing.
            _dbContext = dbContext;

            byte[] response = GenerateResponseBinary(context);
            context.Response.ContentType = GetContentType();
            await context.Response.Body.WriteAsync(response);

            // Clean up.
        }
        private byte[] GenerateResponseBinary(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request.Query["img"]);
            var Image = _dbContext.Multimedia.First(x => x.MultimediumId == id).Image;
            return Image;
        }
        private string GetContentType()
        {
            return "image/jpeg";
        }
    }

    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}