using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using TransfloTask.Shared.GlobalException;

namespace TransfloTask.Shared.Handlers
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate next;
        public GlobalExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }

            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ErrorResponse response;
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            if (ex is BusinessException)
            {
                var exception = (BusinessException)ex;
                response = new ErrorResponse(exception.ErrorMessage, exception.Status);
            }

            else
            {
                response = new ErrorResponse(ex.Message, status);
            }

            var result = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(result);
        }
    }
}
