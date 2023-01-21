using CoreAndFood.Models;
using FluentValidation;

namespace CoreAndFood.ValidationRules.Validators
{
    public class FoodValidator : AbstractValidator<Food>
    {
        public FoodValidator()
        {
            RuleFor(f => f.Name).MaximumLength(30).NotEmpty().WithMessage("Food name has 30 characters maximum");
            RuleFor(f => f.Description).MaximumLength(100).NotEmpty().WithMessage("Description has 100 characters maximum");
            RuleFor(f => f.Stock).GreaterThanOrEqualTo(0).NotEmpty();
            RuleFor(f => f.Price).GreaterThanOrEqualTo(0).NotEmpty();
            RuleFor(f => f.CategoryId).NotEmpty().NotNull();
        }
    }
}
