using Frontend;
using Frontend.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();

builder.RootComponents.Add<App>("#app");

// register HttpClient with base address so calls to /api/... go to the hosting backend
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<MonsterLoaderService>();

await builder.Build().RunAsync();
