using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Models.ViewModels
{
    public class CreateCategoryVM
    {
        [Required(ErrorMessage = "Lütfen kategori ismini giriniz!")]
        [MinLength(2, ErrorMessage = "Minimum 2 karakter girebilirsiniz.")]
        [MaxLength(30, ErrorMessage = "Maximum 30 karakter uzunluğunda bir veri girebilirsiniz.")]
        public string CategoryName { get; set; }
    }
}
