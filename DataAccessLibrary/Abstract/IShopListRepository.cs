using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Abstract
{
    public interface IShopListRepository : IRepository<ShopList>
    {
        bool AddProductToList(int productId, int listId, string noteText);
        string GetProductNote(int productId, int listId);
        List<ShopList> GetShopListsWithProducts();
        (string removedProductName, string listName) RemoveProductFromList(int productId, int listId);
        bool UpdateProductNote(int productId, int listId, string? note);
        void UpdateShopListState(int listId);
    }
}
