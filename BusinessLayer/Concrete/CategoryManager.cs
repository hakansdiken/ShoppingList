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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public void Add(Category t)
        {
            categoryRepository.Add(t);
        }

        public void Delete(Category t)
        {
            categoryRepository.Delete(t);
        }

        public List<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public void Update(Category t)
        {
            categoryRepository.Update(t);
        }
    }
}
