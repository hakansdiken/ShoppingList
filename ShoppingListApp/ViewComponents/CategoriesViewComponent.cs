using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingListApp.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedList = TempData["ListId"];
            var categories = _categoryService.GetAll();
            return View(categories);
        }
    }
}
