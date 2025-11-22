using Frontend;
using Frontend.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();

builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped<MonsterLoaderService>();

await builder.Build().RunAsync();
