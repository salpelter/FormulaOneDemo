// TODO: remove template comments throughout the application

using FormulaOneDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<JolpicaApiService>(client =>
{
    client.BaseAddress = new Uri("http://api.jolpi.ca/");
});
builder.Services.AddScoped<RaceMappingService>(); // TODO: should this be before HttpClient?

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Races/Index");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();  // Instead of MapStaticAssets
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Races}/{action=Index}/{id?}");

await app.RunAsync();