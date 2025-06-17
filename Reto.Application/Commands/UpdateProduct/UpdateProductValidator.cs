using FluentValidation;

namespace Reto.Application.Commands.UpdateProduct
{
	public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
	{
		public UpdateProductValidator()
		{
			RuleFor(x => x.Id).NotEmpty();
			RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
			RuleFor(x => x.Description).MaximumLength(1000);
			RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
			RuleFor(x => x.Price).GreaterThan(0);
			RuleFor(x => x.Status).InclusiveBetween(0, 4);
		}
	}
}
