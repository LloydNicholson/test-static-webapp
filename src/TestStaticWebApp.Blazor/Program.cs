using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TestStaticWebApp.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(
    sp => new HttpClient
    {
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
    });

builder.Services
    .AddDbClient()
    .ConfigureHttpClient(
        (sp, client) =>
        {
            client.BaseAddress = new Uri($"{builder.HostEnvironment.BaseAddress}data-api/graphql");
        });

await builder.Build().RunAsync();