namespace Reto.Api.Extensions
{
	public static class CorsExtension
	{
		public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("RZCorsPolicy", builder =>
				{
					builder
						.AllowAnyOrigin()
						.AllowAnyHeader()
						.AllowAnyMethod();
				});
			});

			return services;
		}
	}
}
