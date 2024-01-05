using Microsoft.Extensions.DependencyInjection;
using VehicleHub.Rental.Api.ViewModel;
using VehicleHub.Rental.DAL.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Add configuration sources 
builder.Configuration.AddJsonFile("appsetting.json", optional: true, reloadOnChange: true);

//Add services to the container
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddVehicleRentalContext(builder.Configuration);

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
