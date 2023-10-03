using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        void Add(Category t);
        void Update(Category t);
        void Delete(Category t);
        List<Category> GetAll();
        Category GetById(int id);
    }
}
