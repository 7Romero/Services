using Services.API.Infrastructure.Middlewares;

namespace Services.API.Infrastructure.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app) => app.UseMiddleware<ExceptionHandlingMiddleware>();

        public static IApplicationBuilder UseDbTransaction(this IApplicationBuilder app) => app.UseMiddleware<DbTransactionMiddleware>();
    }
}
