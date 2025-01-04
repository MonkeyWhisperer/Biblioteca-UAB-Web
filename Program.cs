using Biblioteca_Web.Components;

var builder = WebApplication.CreateBuilder(args);

// 1. Add HttpClient service
builder.Services.AddHttpClient();

// 2. Add Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// 3. Map your Razor component endpoints
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
