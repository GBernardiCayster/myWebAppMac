using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

namespace myWebApp.Client {
    internal class Program {
        static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}
