using DataAccessLayer.Concrete;
using DataAccessLibrary.Abstract;
using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Concrete
{
    public class ShopListRepository : Repository<ShopList>, IShopListRepository
    {
        public bool AddProductToList(int productId, int listId, string noteText)
        {
            using (var db = new Context())
            {
                var list = db.ShopLists.Include(x => x.Products).Where(x => x.ShopListId == listId).FirstOrDefault();
                if (list != null && list.State == true)
                {
                    var isAddedBefore = list.Products.Any(p => p.ProductId == productId);
                    if (!isAddedBefore)
                    {
                        list.Products.Add(new ProductShopList()
                        {
                            ProductId = productId,
                            ShopListId = listId,
                            Note = noteText
                        });
                        db.SaveChanges();

                        return false;
                    }
                }

                return true;
            }
        }
        public string GetProductNote(int productId, int listId)
        {
            using (var db = new Context())
            {
                var note = db.ShopLists
                    .Where(x => x.ShopListId == listId)
                    .SelectMany(l => l.Products)
                    .Where(ps => ps.ProductId == productId)
                    .Select(ps => ps.Note)
                    .FirstOrDefault();

                return note ?? "";
            }
        }
        public List<ShopList> GetShopListsWithProducts()
        {
            using (var db = new Context())
            {
                return db.ShopLists.Include(x => x.Products).ThenInclude(ps => ps.Product).ToList();
            }
        }

        public (string removedProductName, string listName) RemoveProductFromList(int productId, int listId)
        {
            using (var db = new Context())
            {
                var list = db.ShopLists.Where(x => x.ShopListId == listId).Include(x => x.Products).ThenInclude(ps => ps.Product).FirstOrDefault();
                if (list != null)
                {
                    var product = list.Products.Where(p => p.ProductId == productId).FirstOrDefault();
                    if (product != null)
                    {
                        var deletedProduct = product.Product.ProductName;
                        var listName = list.ShopListName;

                        list.Products.Remove(product);
                        db.SaveChanges();
                        return (deletedProduct, listName);
                    }
                }

                return (null, null);
            }

        }

        public bool UpdateProductNote(int productId, int listId, string? note)
        {
            using (var db = new Context())
            {
                var list = db.ShopLists.Where(l => l.ShopListId == listId).Include(l => l.Products).FirstOrDefault();
                if (list != null)
                {
                    var product = list.Products.Where(p => p.ProductId == productId).FirstOrDefault();
                    if (product != null)
                    {
                        product.Note = note;
                        db.SaveChanges();
                        return true;
                    }
                }
                return false;
            }
        }

        public void UpdateShopListState(int listId)
        {
            using (var db = new Context())
            {
                var list = db.ShopLists.Where(s => s.ShopListId == listId).FirstOrDefault();
                if (list != null)
                {
                    list.State = !list.State;
                    db.SaveChanges();
                }
            };
        }
    }
}
