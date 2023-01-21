using CoreAndFood.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
	public class DefaultController : Controller
	{
		IFoodRepository _foodRepository;
		ICategoryRepository _categoryRepository;

		public DefaultController(IFoodRepository foodRepository, ICategoryRepository categoryRepository)
		{
			_foodRepository = foodRepository;
			_categoryRepository = categoryRepository;
		}

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult GetFoodsByCategoryId(int id)
		{
			ViewBag.x = id;

			ViewBag.catname = _categoryRepository.Get(id);

			return View();
		}
	}
}
