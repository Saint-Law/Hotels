using Hotels.Configuration;
using Hotels.Contracts;
using Hotels.Data;
using Hotels.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("HotelListingCon");
builder.Services.AddDbContext<HotelDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding Cors to the program base
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        c => c.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod());
});

//configuring the Serilog
builder.Host.UseSerilog((context, loggerCon) => loggerCon.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<IHotelsRepository, HotelsRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//adding serilog request logging
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("AllowALl");

app.UseAuthorization();

app.MapControllers();

app.Run();
