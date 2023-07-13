using HotelListing.Configurations;
using HotelListing.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var cons = builder.Configuration.GetConnectionString("mystr");
builder.Services.AddDbContext<databaseContext>(Options =>
Options.UseSqlServer(cons)
    ); 
// Add services to the container.
// Add services to the container.

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddControllers();
builder.Services.AddCors(o =>
{
    o.AddPolicy("allowUsers", builder => 
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
builder.Services.AddAutoMapper(typeof(MapperInitializer));
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
app.UseCors("allowUsers");
app.UseAuthorization();

app.MapControllers();

app.Run();
