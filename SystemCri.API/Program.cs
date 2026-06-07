using SystemCri.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Registramos de forma limpia la infraestructura y los repositorios
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();