using CoreAndFood.Models;
using CoreAndFood.Models.ViewModels;
using FluentValidation;

namespace CoreAndFood.ValidationRules.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).MaximumLength(20).NotEmpty().NotNull().WithMessage("Category Name has required");
            RuleFor(c => c.CategoryDescription).MaximumLength(50).NotEmpty();
        }
    }
}
