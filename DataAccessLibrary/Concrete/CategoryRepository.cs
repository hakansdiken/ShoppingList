using DataAccessLibrary.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
    }
}
