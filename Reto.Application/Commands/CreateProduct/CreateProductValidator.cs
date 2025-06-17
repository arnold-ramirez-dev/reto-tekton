﻿using FluentValidation;

namespace Reto.Application.Commands.CreateProduct
{
	public class CreateProductValidator : AbstractValidator<CreateProductCommand>
	{
		public CreateProductValidator()
		{
			RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
			RuleFor(x => x.Description).MaximumLength(1000);
			RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
			RuleFor(x => x.Price).GreaterThan(0);
			RuleFor(x => x.Status).InclusiveBetween(0, 4);
		}
	}
}
