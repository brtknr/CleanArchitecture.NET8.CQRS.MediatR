using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application;
using Microsoft.Extensions.Logging;
using CleanArchitecture.Application.Common.Behaviors;
using Exceptions;

namespace CleanArchitecture.Api.Middlewares
{
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException exception)
            {
                //_logger.LogError("Validation error : {@errors}", exception.Message);
                await HandleValidationException(context, exception);
            }
            catch (Exception exception) 
            {
                _logger.LogError("Error has occured : {@errors}", exception.Message);
                await context.Response.WriteAsJsonAsync(exception.Message);
            }
        }


        private static Task HandleValidationException(HttpContext context , ValidationException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "ValidationFailure",
                Title = "Validation error",
                Detail = "One or more validation errors has occurred",
            };

            if (exception.errors is not null)
            {
                var errorList = new List<ValidationError>();

                foreach (ValidationError err in (dynamic)exception.errors)
                {
                    errorList.Add(err);       
                }

                problemDetails.Extensions["errors"] = errorList;
            }

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            return context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
