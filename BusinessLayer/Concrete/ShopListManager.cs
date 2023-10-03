using BusinessLayer.Abstract;
using DataAccessLibrary.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ShopListManager : IShopListService
    {
        private readonly IShopListRepository shopListRepository;
        public ShopListManager(IShopListRepository shopListRepository)
        {
            this.shopListRepository = shopListRepository;
        }
        public void Add(ShopList t)
        {
            shopListRepository.Add(t);
        }

        public bool AddProductToList(int productId, int listId, string noteText)
        {
            return shopListRepository.AddProductToList(productId, listId, noteText);
        }

        public void Delete(ShopList t)
        {
            shopListRepository.Delete(t);
        }

        public List<ShopList> GetAll()
        {
            return shopListRepository.GetAll();
        }

        public ShopList GetById(int id)
        {
            return shopListRepository.GetById(id);
        }

        public string GetProductNote(int productId, int listId)
        {
            return shopListRepository.GetProductNote(productId, listId);
        }

        public List<ShopList> GetShopListsWithProducts()
        {
            return shopListRepository.GetShopListsWithProducts();
        }

        public (string removedProductName, string listName) RemoveProductFromList(int productId, int listId)
        {
            return shopListRepository.RemoveProductFromList(productId, listId);
        }

        public void Update(ShopList t)
        {
            shopListRepository.Update(t);
        }

        public bool UpdateProductNote(int productId, int listId, string? note)
        {
            return shopListRepository.UpdateProductNote(productId, listId, note);
        }

        public void UpdateShopListState(int listId)
        {
            shopListRepository.UpdateShopListState(listId);
        }
    }
}
