using Usuario.Api.Middleware;

namespace Usuario.Api.Extensions;

public static class ApplicationBuilderExtension
{
    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}