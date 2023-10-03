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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public List<Product> GetProductsBySearch(string stringForSearch)
        {
            using (var db = new Context())
            {
                var products = db.Products.Where(p => p.ProductName.ToLower().Contains(stringForSearch));
                return products.ToList();
            }
        }

        public List<Product> GetProductsWithCategoryName(string categoryName)
        {
            using(var db = new Context())
            {
                var products = db.Products.Include(p=>p.Category).AsQueryable();

                if (!string.IsNullOrEmpty(categoryName))
                {
                    products = products.Where(p => p.Category.CategoryName.ToLower().Replace(" ","") == categoryName);
                }

                return products.ToList();
            }
        }
    }
}
