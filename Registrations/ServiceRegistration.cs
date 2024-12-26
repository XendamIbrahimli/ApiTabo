using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using Tabo.Exceptions;
using Tabo.Services.Abstracts;
using Tabo.Services.Implements;

namespace Tabo.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IWordService, WordService>();
            services.AddScoped<IBannedWordService, BannedWordService>();
            services.AddScoped<IGameService, GameService>();
            return services;
        }

        public static IApplicationBuilder UseTaboExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(opt =>
            {
                opt.Run(async context =>
                {
                    var feature = context.Features.GetRequiredFeature<IExceptionHandlerFeature>();
                    var exception = feature.Error;
                    if (exception is IBaseException bEx)
                    {
                        context.Response.StatusCode = bEx.StatusCode;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            StatusCode = bEx.StatusCode,
                            Message = bEx.ErrorMessage
                        });
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsJsonAsync(new
                        {
                            Message = "Error was occured."
                        });
                    }
                });
            });
            return app; 
        }
    }
}
