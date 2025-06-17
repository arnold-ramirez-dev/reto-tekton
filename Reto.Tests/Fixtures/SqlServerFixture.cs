using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Reto.Infrastructure.Contexts;

namespace Reto.Tests.Fixtures
{
    public sealed class SqlServerFixture : IAsyncLifetime
    {
        public RetoDbContext Context { get; private set; } = default!;
        public IConfiguration Configuration { get; private set; } = default!;

        public async Task InitializeAsync()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.Test.json", optional: false)
                .Build();

            var opts = new DbContextOptionsBuilder<RetoDbContext>()
                .UseSqlServer(Configuration.GetConnectionString("WriteDb"))
                .Options;

            Context = new RetoDbContext(opts);
            await Context.Database.MigrateAsync();
        }

        public Task DisposeAsync() =>
            Context?.DisposeAsync().AsTask() ?? Task.CompletedTask;
    }
}
