using ElectricityComparisonBackend.Repository;
using ElectricityComparisonBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add CORS
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowSpecificOrigin", policy =>
  {
    policy.WithOrigins(
        "http://localhost:4205", //docker/prod
        "http://localhost:4200" //local
        ) // Füge die URL des Frontends hinzu
      .AllowAnyHeader()                      // Erlaube alle Header
      .AllowAnyMethod();                     // Erlaube alle HTTP-Methoden
  });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICalculationService, CalculationService>();
builder.Services.AddScoped<IExternalTariffProvider, ExternalTariffProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
