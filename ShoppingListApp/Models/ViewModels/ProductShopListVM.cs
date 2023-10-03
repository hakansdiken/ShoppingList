namespace ShoppingListApp.Models.ViewModels
{
    public class ProductShopListVM
    {
        public int ListId { get; set; }
        public int ProductId { get; set; }
        public string? Note { get; set; }
        public bool IsBought { get; set; }
    }
}
