using CoreAndFood.Contexts;
using CoreAndFood.Models;
using CoreAndFood.Repositories;
using CoreAndFood.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
	public class FoodController : Controller
	{
		IFoodRepository _foodRepository;
		Context c = new Context();

        public FoodController(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public IActionResult Index(int page = 1)
		{
			

			return View(_foodRepository.GetFoodWithCategory().ToPagedList(page,8));
		}
		
		public IActionResult AddFood()
		{
			List<SelectListItem> values = (from x in c.Categories.ToList()
										   select new SelectListItem
										   {
											   Text= x.CategoryName,
											   Value = x.Id.ToString()
										   }).ToList();	

			ViewBag.values1 = values;

			return View();
		}

		[HttpPost]
        public IActionResult AddFood(AddProduct food)
        {
			Food f = new Food();

			if(food.ImageUrl!= null)
			{
				var extension = Path.GetExtension(food.ImageUrl.FileName);
				var newImageName = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/resimler/",newImageName);
				var stream = new FileStream(location, FileMode.Create);
				food.ImageUrl.CopyTo(stream);
				f.ImageUrl = newImageName;
			}

			f.Name = food.Name;
			f.Description = food.Description;
			f.Price= food.Price;
			f.Stock= food.Stock;
			f.CategoryId= food.CategoryId;

			_foodRepository.Add(f);

            return RedirectToAction("Index");
        }

		public IActionResult DeleteFood(int id)
		{
			_foodRepository.DeleteById(id);

			return RedirectToAction("Index");
		}


		public IActionResult GetFood(int id)
		{
			var food = _foodRepository.Get(id);

            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.Id.ToString()
                                           }).ToList();

            ViewBag.values1 = values;

            Food newFood = new()
			{
				Id= food.Id,
				CategoryId= food.CategoryId,
				Name= food.Name,
				Price= food.Price,
				Stock= food.Stock,
				Description= food.Description,
				ImageUrl= food.ImageUrl
			};

			return View(newFood);
		}

		public IActionResult EditFood(Food food)
		{
			var updatedFood = _foodRepository.Get(food.Id);

			updatedFood.Name= food.Name;
			updatedFood.Stock= food.Stock;
			updatedFood.Price= food.Price;
			updatedFood.ImageUrl = food.ImageUrl;
			updatedFood.Description = food.Description;
			updatedFood.CategoryId= food.CategoryId;

			_foodRepository.Update(updatedFood);

			return RedirectToAction("Index");

		}
    }
}
