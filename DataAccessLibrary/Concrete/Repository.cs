using DataAccessLayer.Concrete;
using DataAccessLibrary.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public void Add(T t)
        {
            using (var db = new Context())
            {
                db.Set<T>().Add(t);
                db.SaveChanges();
            }
        }

        public void Delete(T t)
        {
            using(var db = new Context())
            {
                db.Set<T>().Remove(t);
                db.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using(var db = new Context())
            {
                return db.Set<T>().ToList();
            }
        }

        public T GetById(int id)
        {
            using (var db = new Context())
            {
                return db.Set<T>().Find(id);
            }
        }

        public void Update(T t)
        {
            using (var db = new Context())
            {
                db.Set<T>().Update(t);
                db.SaveChanges();
            }

        }
    }
}
