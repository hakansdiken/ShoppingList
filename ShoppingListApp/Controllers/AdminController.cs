using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        // PRODUCT
        public IActionResult AllProducts()
        {
            var products = _productService.GetAll();

            return View(products);
        }

        public IActionResult CreateProduct()
        {
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync(CreateProductVM vm, IFormFile file)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_categoryService.GetAll(), "CategoryId", "CategoryName");
                return View(vm);
            }

            var product = new Product()
            {
                ProductName = vm.ProductName,
                CategoryId = vm.CategoryId,
            };

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);

                var randomName = string.Format($"{Guid.NewGuid()}{extension}");

                product.ProductImage = randomName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            _productService.Add(product);

            var msg = new AlertMessage()
            {
                AlertType = "success",
                Message = $"{product.ProductName} ürünü başarıyla oluşturuldu.",
            };
            TempData["Message"] = JsonSerializer.Serialize(msg);
            return RedirectToAction("AllProducts");
        }
        public IActionResult DeleteProduct(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var product = _productService.GetById((int)productId);
            if (product != null)
            {
                _productService.Delete(product);
                var msg = new AlertMessage()
                {
                    AlertType = "success",
                    Message = $"{product.ProductName} ürünü başarıyla silindi.",
                };
                TempData["Message"] = JsonSerializer.Serialize(msg);

            }
            return RedirectToAction("AllProducts");
        }

        [HttpGet]
        public IActionResult EditProduct(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var product = _productService.GetById((int)productId);

            var vm = new EditProductVM()
            {
                ProductId = product.ProductId,
                CategoryId = product.CategoryId,
                ProductName = product.ProductName,
                ProductImage = product.ProductImage,
            };

            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "CategoryId", "CategoryName");
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(EditProductVM vm, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = new SelectList(_categoryService.GetAll(), "CategoryId", "CategoryName");
                return View(vm);
            }
            var product = _productService.GetById(vm.ProductId);

            if (product == null)
            {
                return NotFound();
            }

            product.ProductName = vm.ProductName;
            product.CategoryId = vm.CategoryId;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);

                var randomName = string.Format($"{Guid.NewGuid()}{extension}");

                product.ProductImage = randomName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            _productService.Update(product);
            var msg = new AlertMessage()
            {
                AlertType = "success",
                Message = $"{product.ProductName} ürünü başarıyla düzenlendi.",
            };
            TempData["Message"] = JsonSerializer.Serialize(msg);

            return RedirectToAction("AllProducts");
        }
    }
}
