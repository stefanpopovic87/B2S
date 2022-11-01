using B2S.Client.ExternalApi;
using B2S.Contract.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace B2S.Client.Extensions
{
    public static class AspNetCoreExtensions
    {
        public static void AddExternalApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            var configSection = configuration.GetSection(nameof(ExternalApiSettings));
            var settings = configSection.Get<ExternalApiSettings>();

            services.Configure<ExternalApiSettings>(configSection);
            services.AddScoped(cfg => cfg.GetService<IOptionsSnapshot<ExternalApiSettings>>().Value);

            var externalApiSettings = configuration.GetSection(nameof(ExternalApiSettings)).Get<ExternalApiSettings>();
            if (externalApiSettings == null)
            {
                throw new Exception("ClientApiSettings section does not exists in appsettings file.");
            }

            services.AddHttpClient<IExternalApiClient, ExternalApiClient>();
        }
    }
}