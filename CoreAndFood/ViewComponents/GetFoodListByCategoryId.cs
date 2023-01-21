using CoreAndFood.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
	public class GetFoodListByCategoryId : ViewComponent
	{
		IFoodRepository _foodRepository;

		public GetFoodListByCategoryId(IFoodRepository foodRepository)
		{
			_foodRepository = foodRepository;
		}

		public IViewComponentResult Invoke(int id)
		{
			var foodList = _foodRepository.GetAll(f => f.CategoryId == id);
			return View(foodList);
		}
	}
}
