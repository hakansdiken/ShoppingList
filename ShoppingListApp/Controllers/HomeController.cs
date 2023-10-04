using BusinessLayer.Abstract;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ShoppingListApp.Models;
using ShoppingListApp.Models.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;

namespace ShoppingListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShopListService _shopListService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public HomeController(IShopListService shopListService, IProductService productService, ICategoryService categoryService)
        {
            _shopListService = shopListService;
            _productService = productService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var shopLists = _shopListService.GetShopListsWithProducts();
            var shopListVM = new ShopListVM()
            {
                ShopLists = shopLists,
            };
            return View(shopListVM);
        }

        public IActionResult ListProduct(int listId, string categoryName, string stringForSearch)
        {
            if (listId == 0)
            {
                return RedirectToAction("Index");
            }


            var products = _productService.GetProductsWithCategoryName(categoryName);

            if (!string.IsNullOrEmpty(stringForSearch))
            {
                products = _productService.GetProductsBySearch(stringForSearch);

            }

            var productVM = new ProductVM()
            {

                Products = products,
            };
            TempData["ListId"] = listId;
            return View(productVM);
        }

        [HttpPost]
        public IActionResult AddProductToList(ProductShopListVM vm)
        {

            if (vm.ProductId == 0 || vm.ListId == 0)
            {
                return NotFound();
            }
            var list = _shopListService.GetById(vm.ListId);
            var isAddedBefore = _shopListService.AddProductToList(vm.ProductId, vm.ListId, vm.Note);
            var msg = new AlertMessage();

            if (!list.State)
            {
                msg.AlertType = "danger";
                msg.Message = "Alışverişteyken listenize ürün ekleyemezsiniz!";
                TempData["Message"] = JsonSerializer.Serialize(msg);

            }
            else
            {
                if (isAddedBefore)
                {
                    msg.AlertType = "danger";
                    msg.Message = "Bu ürün daha önce listenize eklenmiştir.";

                }
                else
                {
                    msg.AlertType = "success";
                    msg.Message = "Ürün listenize eklenmiştir.";
                }
                TempData["Message"] = JsonSerializer.Serialize(msg);
            }


            return Redirect("/Home/ListProduct?listId=" + vm.ListId);
        }

        public IActionResult RemoveProductFromList(int productId, int listId)
        {
            var (removedProductName, listName) = _shopListService.RemoveProductFromList(productId, listId);
            if (removedProductName != null && listName != null)
            {
                var msg = new AlertMessage()
                {
                    AlertType = "success",
                    Message = $"{removedProductName} adlı ürün {listName} listesinden silinmiştir."
                };
                TempData["Message"] = JsonSerializer.Serialize(msg);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ProductDetail(int productId, int listId)
        {
            if (productId == 0 || listId == 0)
                return NotFound();

            string note = _shopListService.GetProductNote(productId, listId);

            var vm = new ProductShopListVM()
            {
                ProductId = productId,
                ListId = listId,
                Note = note
            };
            var result = View(vm);
            return result;
        }
        [HttpPost]
        public IActionResult ProductDetail(ProductShopListVM vm)
        {
            var isUpdated = _shopListService.UpdateProductNote(vm.ProductId, vm.ListId, vm.Note);
            if (isUpdated)
            {
                var msg = new AlertMessage()
                {
                    AlertType = "success",
                    Message = "Ürün notu başarıyla güncellendi"
                };
                TempData["Message"] = JsonSerializer.Serialize(msg);
            }

            return Redirect("Index");
        }

        public IActionResult CreateShopList()
        {
            var vm = new CreateShopListVM();
            return View(vm);
        }

        [HttpPost]
        public IActionResult CreateShopList(CreateShopListVM vm)
        {
            if (ModelState.IsValid)
            {
                var shopList = new ShopList()
                {
                    ShopListName = vm.ShopListName
                };
                _shopListService.Add(shopList);

                return RedirectToAction("Index");
            }
            return View(vm);
        }
        public IActionResult DeleteShopList(int listId)
        {
            if (listId == null)
            {
                return NotFound();
            }
            else
            {
                var deletedList = _shopListService.GetById(listId);
                if (deletedList != null)
                {
                    _shopListService.Delete(deletedList);
                    var msg = new AlertMessage()
                    {
                        AlertType = "success",
                        Message = $"{deletedList.ShopListName} listeniz başarıyla silindi."
                    };
                    TempData["Message"] = JsonSerializer.Serialize(msg);
                }
            }
            return RedirectToAction("Index");

        }
        public IActionResult UpdateShopListState(int listId)
        {
            //_shopListService.
            _shopListService.UpdateShopListState(listId);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateProductState(ShopListVM vm)
        {
            _productService.UpdateProductState(vm.ProductIds, vm.ShopListId);

            return RedirectToAction("Index");
        }
    }

}