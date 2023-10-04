using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Models;
using ShoppingListApp.Models.ViewModels;
using System.Collections.Generic;
using System.Text.Json;

namespace ShoppingListApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult AllCategories()
        {
            var categories = _categoryService.GetAll();

            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var category = new Category()
            {
                CategoryName = vm.CategoryName,
            };
            _categoryService.Add(category);
            var msg = new AlertMessage()
            {
                AlertType = "success",
                Message = $"{category.CategoryName} kategorisi başarıyla oluşturuldu.",
            };
            TempData["Message"] = JsonSerializer.Serialize(msg);
            return RedirectToAction("AllCategories");
        }
        [HttpGet]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (categoryId != null)
            {
                var category = _categoryService.GetById(categoryId);

                if (category != null)
                {
                    _categoryService.Delete(category);
                    var msg = new AlertMessage()
                    {
                        AlertType = "success",
                        Message = $"{category.CategoryName} kategorisi başarıyla silindi.",
                    };
                    TempData["Message"] = JsonSerializer.Serialize(msg);

                    return RedirectToAction("AllCategories");
                }

            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult EditCategory(int categoryId)
        {
            if (categoryId == null)
            {
                return NotFound();
            }

            var c = _categoryService.GetById(categoryId);

            if (c != null)
            {
                var vm = new EditCategoryVM()
                {
                    CategoryName = c.CategoryName,
                    Id = c.CategoryId
                };
                return View(vm);

            }
            else
                return NotFound();

        }
        [HttpPost]
        public IActionResult EditCategory(EditCategoryVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var updatedCategory = _categoryService.GetById(vm.Id);

            updatedCategory.CategoryName = vm.CategoryName;

            _categoryService.Update(updatedCategory);
            var msg = new AlertMessage()
            {
                AlertType = "success",
                Message = "Kategori başarıyla güncellendi.",
            };
            TempData["Message"] = JsonSerializer.Serialize(msg);
            return RedirectToAction("AllCategories");
        }
    }
}
