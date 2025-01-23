// TODO: remove template comments throughout the application

using FormulaOneDemo.Middleware;
using FormulaOneDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<JolpicaApiService>(client =>
{
    client.BaseAddress = new Uri("http://api.jolpi.ca/");
});
builder.Services.AddScoped<RaceMappingService>(); // TODO: should this be before HttpClient?
builder.Services.AddTransient<PrintHelloMiddleware>();

var app = builder.Build();

app.UseMiddleware<PrintHelloMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Races/Index");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Races}/{action=Index}/{id?}");

await app.RunAsync();