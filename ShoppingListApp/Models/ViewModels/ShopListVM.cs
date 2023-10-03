using EntityLayer.Entities;

namespace ShoppingListApp.Models.ViewModels
{
    public class ShopListVM
    {
        public List<ShopList> ShopLists { get; set; }
        public int[] ProductIds { get; set; }
        public int ShopListId { get; set; }
    }
}
