using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProductsBySearch(string stringForSearch);
        List<Product> GetProductsWithCategoryName(string categoryName);
        void UpdateProductState(int[] productIds, int shopListId);
    }
}
