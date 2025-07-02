using InitiativeTracker.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MonsterLoaderService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

var monsterLoaderService = app.Services.GetRequiredService<MonsterLoaderService>();
string folderPathForMonsters = @"./Default Monsters";
MonstersReader.ReadAllMonstersData(folderPathForMonsters, monsterLoaderService);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
