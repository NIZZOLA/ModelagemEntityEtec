using Microsoft.EntityFrameworkCore;
using AnunciosAPI.Data;
using AnunciosAPI;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AnunciosAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AnunciosAPIContext") ?? throw new InvalidOperationException("Connection string 'AnunciosAPIContext' not found.")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapClienteEndpoints();

app.Run();
