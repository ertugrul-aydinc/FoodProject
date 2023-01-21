using CoreAndFood.Models;
using CoreAndFood.Models.DTOs;
using System.Linq.Expressions;

namespace CoreAndFood.Repositories.Abstract
{
    public interface IFoodRepository : IRepository<Food>
    {
        List<FoodWithCategoryName> GetFoodWithCategory(Expression<Func<FoodWithCategoryName, bool>> filter = null);
    }
}
