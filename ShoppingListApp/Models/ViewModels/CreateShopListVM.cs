using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Models.ViewModels
{
    public class CreateShopListVM
    {
        [Required(ErrorMessage = "Lütfen liste ismini giriniz!")]
        [MaxLength(30, ErrorMessage = "Liste ismi fazla uzun!")]
        [MinLength(3, ErrorMessage = "Liste ismi fazla kısa!")]
        public string ShopListName { get; set; }
    }
}
