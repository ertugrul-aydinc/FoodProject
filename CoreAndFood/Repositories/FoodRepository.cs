using CoreAndFood.Contexts;
using CoreAndFood.Models;
using CoreAndFood.Models.DTOs;
using CoreAndFood.Repositories.Abstract;
using System.Linq.Expressions;

namespace CoreAndFood.Repositories
{
    public class FoodRepository : GenericRepository<Food>, IFoodRepository
    {
        public List<FoodWithCategoryName> GetFoodWithCategory(Expression<Func<FoodWithCategoryName, bool>> filter = null)
        {
            using(var context = new Context())
            {
                var result = from food in context.Foods
                             join cat in context.Categories
                             on food.CategoryId equals cat.Id
                             select new FoodWithCategoryName
                             {
                                 Id = food.Id,
                                 Name = food.Name,
                                 CategoryName = cat.CategoryName,
                                 ImageUrl = food.ImageUrl,
                                 Price = food.Price,
                                 Stock = food.Stock,
                                 CategoryId = cat.Id,
                                 Description = food.Description,

                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }


        }
    }
}
