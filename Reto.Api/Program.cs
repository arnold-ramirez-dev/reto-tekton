using Reto.Api.Extensions;
using Reto.Api.Middlewares;
using Reto.Application.Extensions;
using Reto.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddCorsPolicy();

var app = builder.Build();

app.UseMiddleware<ResponseTimeMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseSwaggerDocumentation();

app.UseHttpsRedirection();
app.UseCors("RZCorsPolicy");
app.UseAuthorization();
app.MapControllers();

app.Run();
