using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IShopListService
    {
        void Add(ShopList t);
        void Update(ShopList t);
        void Delete(ShopList t);
        List<ShopList> GetAll();
        ShopList GetById(int id);
        List<ShopList> GetShopListsWithProducts();
        bool AddProductToList(int productId, int listId, string noteText);
        (string removedProductName, string listName) RemoveProductFromList(int productId, int listId);
        string GetProductNote(int productId, int listId);
        bool UpdateProductNote(int productId, int listId, string? note);
        void UpdateShopListState(int listId);
    }
}
