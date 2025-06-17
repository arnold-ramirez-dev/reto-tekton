using System.Diagnostics;

namespace Reto.Api.Middlewares
{
	public sealed class ResponseTimeMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<ResponseTimeMiddleware> _logger;
		private readonly string _logFile;

		public ResponseTimeMiddleware(RequestDelegate next, ILogger<ResponseTimeMiddleware> logger, IWebHostEnvironment env)
		{
			_next = next;
			_logger = logger;

			var logDir = Path.Combine(env.ContentRootPath, "Logs");
			Directory.CreateDirectory(logDir);
			_logFile = Path.Combine(logDir, "response-times.log");
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var sw = Stopwatch.StartNew();
			await _next(context);
			sw.Stop();

			var line =
				$"{DateTime.UtcNow:o}|{context.Request.Method} {context.Request.Path}|{sw.ElapsedMilliseconds}ms{Environment.NewLine}";

			await File.AppendAllTextAsync(_logFile, line);
		}
	}

}
