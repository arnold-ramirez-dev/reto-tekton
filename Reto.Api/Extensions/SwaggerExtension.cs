using Microsoft.OpenApi.Models;

namespace Reto.Api.Extensions
{
	public static class SwaggerExtension
	{
		public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "Reto API Clean Architecture",
					Version = "v1",
					Description = "Arnold Ramírez",
					Contact = new OpenApiContact
					{
						Name = "Arnold Ramírez",
						Email = "arnold.ramirez.zavaleta@gmail.com"
					}
				});
			});

			return services;
		}

		public static WebApplication UseSwaggerDocumentation(this WebApplication app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reto API v1");
				c.RoutePrefix = string.Empty;
				c.DisplayRequestDuration();
				c.DefaultModelsExpandDepth(-1);
			});

			return app;
		}
	}
}
