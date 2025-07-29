namespace QuickEnrol.Client
{
    using Microsoft.AspNetCore.Components.Web;
    using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
    using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMsalAuthentication(options =>
            {
                builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
                options.AuthenticationPaths.LogInPath = "authentication/login";
                options.AuthenticationPaths.LogOutPath = "authentication/logout";
                options.AuthenticationPaths.LogInCallbackPath = "authentication/login-callback";
                options.AuthenticationPaths.LogOutCallbackPath = "authentication/logout-callback";
                options.AuthenticationPaths.RemoteRegisterPath = "/";
                options.AuthenticationPaths.RemoteProfilePath = "/";
            });

            await builder.Build().RunAsync();
        }
    }
}
