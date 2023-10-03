using BusinessLayer.Abstract;
using DataAccessLibrary.Abstract;
using DataAccessLibrary.Concrete;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public void Add(Product t)
        {
            productRepository.Add(t);
        }

        public void Delete(Product t)
        {
            productRepository.Delete(t);
        }

        public List<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return  productRepository.GetById(id);
        }

        public List<Product> GetProductsBySearch(string stringForSearch)
        {
            return productRepository.GetProductsBySearch(stringForSearch);
        }

        public List<Product> GetProductsWithCategoryName(string categoryName)
        {
            return productRepository.GetProductsWithCategoryName(categoryName);
        }

        public void Update(Product t)
        {
            productRepository.Update(t);
        }
    }
}
