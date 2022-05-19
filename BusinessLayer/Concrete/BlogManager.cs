using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogdal;

        public BlogManager(IBlogDal blogdal)
        {
            _blogdal = blogdal;
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogdal.GetListWithCategory();
        }
        public List<Blog> GetBlogById(int id)
        {
            return _blogdal.GetAll(x => x.BlogID == id);
        }
        public Blog TGetById(int id)
        {
            return _blogdal.GetById(id);
        }

        public List<Blog> GetList()
        {
            return _blogdal.GetAll();
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogdal.GetAll(m => m.WriterID == id);
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogdal.GetAll().Take(3).ToList();
        }
        public List<Blog> GetListWithCategoryWriterBm(int id)
        {
            return _blogdal.GetListWithCategoryWriter(id);
        }
        public void TAdd(Blog entity)
        {
            _blogdal.Add(entity);
        }

        public void TDelete(Blog entity)
        {
            _blogdal.Delete(entity);
        }

        public void TUpdate(Blog entity)
        {
            _blogdal.Update(entity);
        }
    }
}
