using CoreAndFood.Contexts;
using CoreAndFood.CQRS.Commands.Food.AddFood;
using CoreAndFood.CQRS.Commands.Food.EditFood;
using CoreAndFood.Models;
using CoreAndFood.Repositories;
using CoreAndFood.Repositories.Abstract;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood.Controllers
{
    public class FoodController : Controller
	{
		IFoodRepository _foodRepository;
		IMediator _mediator;
		Context c = new Context();

        public FoodController(IFoodRepository foodRepository, IMediator mediator)
        {
            _foodRepository = foodRepository;
			_mediator = mediator;
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
        public IActionResult AddFood(AddFoodCommandRequest addFoodCommandRequest)
        {
			_mediator.Send(addFoodCommandRequest);
            return RedirectToAction("Index");
        }


		public IActionResult DeleteFood(DeleteFoodCommandRequest deleteFoodCommandRequest)
		{
			_mediator.Send(deleteFoodCommandRequest);
			//_foodRepository.DeleteById(id);

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

		public IActionResult EditFood(EditFoodCommandRequest editFoodCommandRequest)
		{
			_mediator.Send(editFoodCommandRequest);
			return RedirectToAction("Index");
		}
    }
}
