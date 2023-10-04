using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Models.ViewModels
{
    public class CreateProductVM
    {
        [Required(ErrorMessage = "Lütfen ürün ismini giriniz!")]
        [MinLength(2, ErrorMessage = "Minimum 2 karakter girebilirsiniz.")]
        [MaxLength(30, ErrorMessage = "Maximum 30 karakter uzunluğunda bir veri girebilirsiniz.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Bu alan Gereklidir")]
        public int CategoryId { get; set; }

    }
}
