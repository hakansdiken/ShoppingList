using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProductService
    {
        void Add(Product t);
        void Update(Product t);
        void Delete(Product t);
        List<Product> GetAll();
        Product GetById(int id);
        List<Product> GetProductsWithCategoryName(string categoryName);
        List<Product> GetProductsBySearch(string stringForSearch);
        void UpdateProductState(int[] productIds, int shopListId);
    }
}
