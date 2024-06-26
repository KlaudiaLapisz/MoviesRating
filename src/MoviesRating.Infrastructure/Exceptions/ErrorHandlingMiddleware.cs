﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MoviesRating.Domain.Exceptions;

namespace MoviesRating.Infrastructure.Exceptions
{
    internal class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                if (ex is MovieRatingException)
                {
                    context.Response.StatusCode = 400;
                    var error = new Error(ex.Message);
                    await context.Response.WriteAsJsonAsync(error);
                }
                else
                {
                    context.Response.StatusCode = 500;
                    var error = new Error("Something went wrong");
                    await context.Response.WriteAsJsonAsync(error);
                }
            }
        }
    }

    internal class Error
    {
        public string Message { get; }
       
        public Error(string message)
        {
            Message = message;
        }
    }
}
