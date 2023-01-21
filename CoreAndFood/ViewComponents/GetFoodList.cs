using CoreAndFood.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
	public class GetFoodList : ViewComponent
	{
		IFoodRepository _foodRepository;

		public GetFoodList(IFoodRepository foodRepository)
		{
			_foodRepository = foodRepository;
		}

		public IViewComponentResult Invoke()
		{
			var foodList = _foodRepository.GetAll();

			return View(foodList);
		}
	}
}
