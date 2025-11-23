using Backend.Interfaces;
using Backend.Services;
using Backend.Utilities;
using Core.Interfaces;
using Frontend;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.AspNetCore.Antiforgery;
using Backend.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- Services ---
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Bind services / DI - keep your existing registrations
builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IEquipmentEntityValidator, EquipmentEntityValidator>();

// Antiforgery & DataProtection
builder.Services.AddAntiforgery(options =>
{
    // Optionally tune header name or cookie name
    options.HeaderName = "X-CSRF-TOKEN";
});

// Persist keys to mounted directory (must exist in container or as a volume)
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("/var/dpkeys"));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Missing connection string.");
builder.Services.AddSingleton<ConnectionSettings>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// --- Build ---
var app = builder.Build();

// Static web assets loader MUST run early to register static resources
StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

// --- Middleware & pipeline ordering ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

// Serve static files (wwwroot that will include the published Blazor assets)
app.UseStaticFiles();

// Antiforgery middleware should be added after static files but before endpoints that require tokens.
// In .NET 8 the antiforgery middleware can validate tokens automatically on endpoints that require it.
app.UseAntiforgery();

// Optional: Authentication/Authorization if you use them
app.UseAuthorization();

// --- Provide an endpoint that issues an antiforgery token to the client ---
app.MapGet("/__antiforgery/token", (IAntiforgery antiforgery, HttpContext http) =>
{
    var tokens = antiforgery.GetAndStoreTokens(http);
    // Return token value in JSON; client can send it back in e.g. X-CSRF-TOKEN header
    return Results.Json(new { token = tokens.RequestToken });
});

// Map interactive components (root component) --- interactive WASM render mode
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode();

// Map controllers / API endpoints
app.MapControllers();

app.Run();
