using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Reto.Application.Commands.CreateProduct;
using Reto.Application.DTOs.Products;
using Reto.Application.Queries.GetProductById;
using Reto.Domain.Interfaces;
using Reto.Domain.ValueObjects;
using Reto.Infrastructure.Implements;
using Reto.Infrastructure.Persistence.Repositories;
using Reto.Shared;
using Reto.Tests.Fixtures;

namespace Reto.Tests
{
    [CollectionDefinition("SqlServer")]
    public sealed class SqlServerCollection : ICollectionFixture<SqlServerFixture> { }

    [Collection("SqlServer")]
    public class GetProductFlowTests
    {
        private readonly SqlServerFixture _fx;
        public GetProductFlowTests(SqlServerFixture fx) => _fx = fx;

        [Fact]
        public async Task Create_then_get_returns_expected_final_price()
        {
            var services = new ServiceCollection()
                .AddSingleton(_fx.Context)
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddMemoryCache()
                .Configure<RZConfig>(_fx.Configuration.GetSection("RZConfig"))
                .AddSingleton<IStatusCache, StatusCache>()
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateProductCommand>())
                .AddHttpClient<IHttpRequester, HttpRequester>()
                .Services
                .AddScoped<IDiscountService, DiscountService>();

            var provider = services.BuildServiceProvider();

            var mediator = provider.GetRequiredService<IMediator>();

            var create = await mediator.Send(new CreateProductCommand
            {
                Name = "Prod",
                Description = "Desc",
                Stock = 5,
                Price = 100,
                Status = VOStatus.Active.Value
            });

            create.IsSuccess.Should().BeTrue();
            var id = create.Data;

            var query = await mediator.Send(new GetProductByIdQuery(id));

            query.IsSuccess.Should().BeTrue();
            var dto = query.Data!.Should().BeOfType<GetProductByIdDto>().Subject;

            dto.StatusName.Should().Be("Active");
            dto.Discount.Should().BeInRange(0, 100);
            dto.FinalPrice.Should().Be(dto.Price - dto.Price * dto.Discount / 100m);
        }
    }
}
