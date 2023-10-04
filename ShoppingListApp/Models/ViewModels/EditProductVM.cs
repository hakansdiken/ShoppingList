using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Models.ViewModels
{
    public class EditProductVM
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Lütfen ürün adını giriniz!")]
        [MinLength(2, ErrorMessage = "Minimum 2 karakter girebilirsiniz.")]
        [MaxLength(30, ErrorMessage = "Maximum 30 karakter uzunluğunda bir veri girebilirsiniz.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Lütfen ürün resmi giriniz!")]
        public string ProductImage { get; set; }
        [Required(ErrorMessage = "Lütfen kategori giriniz!")]
        public int CategoryId { get; set; }
    }
}
