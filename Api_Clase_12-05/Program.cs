using Api_Clase_12_05.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Api_Clase_12_05.Business.PersonaBusiness;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextDB>(options =>
{
    options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=prueba;User Id=ema;Password=1234;");
});

builder.Services.AddMediatR(typeof(GetPersonasById).Assembly);

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
