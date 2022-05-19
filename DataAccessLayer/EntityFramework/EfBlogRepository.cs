using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetListWithCategory()
        {
            using (Context db = new Context())
            {
                return db.Blogs.Include(m => m.Category).ToList();
            }
        }

        public List<Blog> GetListWithCategoryWriter(int id)
        {
            using (Context db = new Context())
            {
                return db.Blogs.Include(m => m.Category).Where(x=>x.WriterID==id).ToList();
            }
        }
    }
}
