using Common.Wrappers;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(
            HttpContext context,
            Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new HttpResponse<object>
            {
                Succeeded = false
            };

            if (exception is ValidationException validationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.ErrorCode = context.Response.StatusCode;
                response.ValidationErrors = validationException.Errors
                    .Select(error => error.ErrorMessage)
                    .ToList();
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.ErrorCode = context.Response.StatusCode;
                response.ErrorMessage = exception.Message;
            }

            return context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}