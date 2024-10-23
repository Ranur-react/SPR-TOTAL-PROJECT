using frontend.Base;
using frontend.Repository.Data;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddScoped<Address>();
services.AddScoped<SPRRepository>();
services.AddScoped<ProyekRepository>();
services.AddScoped<MaterialRepository>();
services.AddCors(e =>
{

    e.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    //                e.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost:44309/TestCors"));
});

// Bind konfigurasi dari appsettings.json
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseCors(options =>
          options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
          //options.WithOrigins("https://localhost:44309")
          );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
