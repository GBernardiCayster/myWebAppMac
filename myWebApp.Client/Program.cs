using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using Blazored.SessionStorage;
using myWebApp.Client;
using myWebApp.Client.Authentication;
using Microsoft.AspNetCore.Components.Authorization;



namespace myWebApp.Client {
    internal class Program {
        static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredSessionStorage();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddAuthorizationCore();

    
            
            builder.Services.AddSyncfusionBlazor();
            //Register Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NAaF1cXmhIfEx1RHxQdld5ZFRHallYTnNWUj0eQnxTdEFjW31WcXBXRWJVVU11Ww==");
            


          
            
            await builder.Build().RunAsync();
        }
    }
}


