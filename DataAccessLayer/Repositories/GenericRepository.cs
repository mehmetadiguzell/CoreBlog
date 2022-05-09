using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Add(T entity)
        {
            using (Context db=new Context())
            {
                db.Add(entity);
            }
        }

        public void Delete(T entity)
        {
            using (Context db = new Context())
            {
                db.Remove(entity);
            }
        }

        public List<T> GetAll()
        {
            using (Context db = new Context())
            {
                return db.Set<T>().ToList();
            }
            
        }

        public T GetById(int id)
        {
            using (Context db = new Context())
            {
                return db.Set<T>().Find(id);
            }
        }

        public void Update(T entity)
        {
            using (Context db = new Context())
            {
                db.Update(entity);
            }
        }
    }
}
