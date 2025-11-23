using Backend.Interfaces;
using Backend.Services;
using Backend.Utilities;
using Core.Interfaces;
using Frontend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Bind settings
//builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

//builder.Services.AddSingleton<IMongoClient>(sp =>
//{
//    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;

//    var credential = MongoCredential.CreateCredential("admin", settings.Username, settings.Password);
//    var mongoSettings = MongoClientSettings.FromUrl(new MongoUrl($"mongodb://{settings.Host}:{settings.Port}"));
//    mongoSettings.Credential = credential;

//    return new MongoClient(mongoSettings);
//});

//builder.Services.AddSingleton<EquipmentRepository>();
//builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IEquipmentEntityValidator, EquipmentEntityValidator>();
//builder.Services.AddScoped<IEquipmentNoSQLService, EquipmentNoSQLService>();
//builder.Services.AddScoped<ILogger, Logger<EquipmentNoSQLService>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
