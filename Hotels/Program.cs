using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowALl");

app.UseAuthorization();

app.MapControllers();

app.Run();