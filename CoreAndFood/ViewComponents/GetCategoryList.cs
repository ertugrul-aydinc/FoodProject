using CoreAndFood.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood.ViewComponents
{
    public class GetCategoryList : ViewComponent
    {
        ICategoryRepository _categoryRepository;

        public GetCategoryList(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var catList = _categoryRepository.GetAll();

            return View(catList);
        }
    }
}
