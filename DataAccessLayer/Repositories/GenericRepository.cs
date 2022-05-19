using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using System.Linq.Expressions;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Add(T entity)
        {
            using (Context db = new Context())
            {
                db.Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (Context db = new Context())
            {
                db.Remove(entity);
                db.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using (Context db = new Context())
            {
                return db.Set<T>().ToList();
            }

        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            using (Context db = new Context())
            {
                return db.Set<T>().Where(filter).ToList();
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
                db.SaveChanges();
            }
        }
    }
}
