using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortalAnuncios.Data;
using System.Text.Json.Serialization;
using System.Text.Json;
using PortalAnuncios.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PortalAnunciosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PortalAnunciosContext") ?? throw new InvalidOperationException("Connection string 'PortalAnunciosContext' not found.")));

//builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)));
//builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
//                                                            | JsonIgnoreCondition.WhenWritingNull);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapEndpoints();

app.Run();
