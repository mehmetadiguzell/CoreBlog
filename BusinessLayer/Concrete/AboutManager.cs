using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public About TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
            return _aboutDal.GetAll();
        }

        public void TAdd(About entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(About entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About entity)
        {
            throw new NotImplementedException();
        }
    }

}
