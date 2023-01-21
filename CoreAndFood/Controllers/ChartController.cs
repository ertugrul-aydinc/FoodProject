using CoreAndFood.Contexts;
using CoreAndFood.Models.Charts;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Index3()
        {
            return View();
        }

        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }

        public List<Class1> ProList()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                proname = "Computer",
                stock = 150
            });
            cs.Add(new Class1()
            {
                proname = "LCD",
                stock = 75
            });
            cs.Add(new Class1()
            {
                proname = "USB Disk",
                stock = 220
            });

            return cs;
        }

        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodList());
        }

        public List<Class2> FoodList()
        {
            List<Class2> foods = new List<Class2>();

            using (var context = new Context())
            {
                foods = context.Foods.Select(x => new Class2
                {
                    foodname = x.Name,
                    stock = x.Stock
                }).ToList();
            }

            return foods;
        }

        public IActionResult GetStatistics()
        {
            Context context= new Context();

            ViewBag.d1 = context.Foods.Count();
            ViewBag.d2 = context.Categories.Count();

            var fruitId = context.Categories.Where(c => c.CategoryName == "Fruit").Select(y => y.Id).FirstOrDefault();
            ViewBag.d3 = context.Foods.Where(f => f.CategoryId == fruitId).Count();

            var vegId = context.Categories.Where(c => c.CategoryName == "Vegetable").Select(y => y.Id).FirstOrDefault();
            ViewBag.d4 = context.Foods.Where(f => f.CategoryId == vegId).Count();

            ViewBag.d5 = context.Foods.Sum(x => x.Stock);

            var legId = context.Categories.Where(c => c.CategoryName == "Legumes").Select(y => y.Id).FirstOrDefault();
            ViewBag.d6 = context.Foods.Where(f => f.CategoryId == legId).Count();

            ViewBag.d7 = context.Foods.OrderByDescending(f => f.Stock).Select(f => f.Name).FirstOrDefault();

            ViewBag.d8 = context.Foods.OrderByDescending(f => f.Stock).Select(f => f.Name).LastOrDefault();

            ViewBag.d9 = context.Foods.Average(f => f.Price).ToString("0.00");

            ViewBag.d10 = context.Foods.Where(f => f.CategoryId == fruitId).Sum(f => f.Stock);

            ViewBag.d11 = context.Foods.Where(f => f.CategoryId == vegId).Sum(f => f.Stock);

            ViewBag.d12 = context.Foods.OrderByDescending(f => f.Price).Select(f => f.Name).FirstOrDefault();


            return View();
        }

    }
}
