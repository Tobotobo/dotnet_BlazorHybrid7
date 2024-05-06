using BlazorHybrid.App.Web.Components;
using BlazorHybrid.App;

var dbPath = Path.Combine(
    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
    "com.github.tobotobo",
    "BlazorHybrid.App",
    "todo.db");
Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApp($"Data Source={dbPath}")
    .AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies([typeof(BlazorHybrid.View.Components.Routes).Assembly]);

app.Run();
