using CoreAndFood.Models;
using CoreAndFood.Models.ViewModels;
using CoreAndFood.Repositories;
using CoreAndFood.Repositories.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
	public class CategoryController : Controller
	{
		readonly ICategoryRepository _categoryRepository;
		readonly IFoodRepository _foodRepository;
		readonly IMediator _mediator;

        public CategoryController(ICategoryRepository categoryRepository, IFoodRepository foodRepository,IMediator mediator)
        {
            _categoryRepository = categoryRepository;
            _foodRepository = foodRepository;
			_mediator = mediator;
        }

        public IActionResult Index(string p)
		{
			if(!string.IsNullOrEmpty(p))
			{
				return View(_categoryRepository.GetAll(x => x.CategoryName.Contains(p)));
			}

			return View(_categoryRepository.GetAll());
		}

		public IActionResult AddCategory()
		{
			return View();
		}

		[HttpPost]
        public IActionResult AddCategory(Category category)
        {
			if (!ModelState.IsValid)
			{
				return View("AddCategory");
			}

			_categoryRepository.Add(category);

			return RedirectToAction("Index");
        }

		public IActionResult GetCategory(int id)
		{
			var cat = _categoryRepository.Get(id);

			Category ct = new()
			{
				CategoryName = cat.CategoryName,
				CategoryDescription = cat.CategoryDescription,
				Id = cat.Id,
				Status = cat.Status

			};

			return View(cat);
		}

		[HttpPost]
		public IActionResult EditCategory(Category category)
		{
			var cat = _categoryRepository.Get(category.Id);

			cat.CategoryName = category.CategoryName;
			cat.CategoryDescription = category.CategoryDescription;
			cat.Status = true;
			_categoryRepository.Update(cat);

			return RedirectToAction("Index");
		}

		
		public IActionResult CategoryDelete(int id)
		{
			var relation = _foodRepository.GetAll(f => f.CategoryId == id).Count();

			var cat = _categoryRepository.Get(id);
			cat.Status = false;
			_categoryRepository.Update(cat);

			if (relation == 0)
				_categoryRepository.Delete(cat);

			return RedirectToAction("Index");
		}
    }
}
