using CommunityToolkit.Maui;
using FreshVegCart.Apis;
using FreshVegCart.Services;
using Microsoft.Extensions.Logging;

using Refit;

namespace FreshVegCart
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                })
                .UseMauiCommunityToolkit();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<CartService>().AddSingleton<AppState>();

            ConfigureRefit(builder.Services);

            return builder.Build();
        }

        private static void ConfigureRefit(IServiceCollection services)
        {
            //const string apiBaseUrl = "https://localhost:7001";
            const string apiBaseUrl = "https://mvgrxdkt-7001.asse.devtunnels.ms";
            services.AddRefitClient<IProductApi>()
                .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IAuthApi>()
                .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IUserApi>(GetRefitSettings)
                .ConfigureHttpClient(SetHttpClient);

            services.AddRefitClient<IOrderApi>(GetRefitSettings)
                .ConfigureHttpClient(SetHttpClient);

            static void SetHttpClient(HttpClient httpClient) => httpClient.BaseAddress = new Uri(apiBaseUrl);

            static RefitSettings GetRefitSettings(IServiceProvider sp)
            {
                var settings = new RefitSettings();
                settings.AuthorizationHeaderValueGetter = (_, __) => Task.FromResult("TOKEN");
                return settings;
            }
        }
    }
}
