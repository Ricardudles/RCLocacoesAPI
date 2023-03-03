using Microsoft.EntityFrameworkCore;
using RCLocacoes.Infra.Data.Context;
using RCLocacoes.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddDIConfiguration();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

app.UseAuthorization();

app.MapControllers();

app.Run();
