using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<AppUser> GetList()
        {
            throw new NotImplementedException();
        }

        public void TAdd(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public AppUser TGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public void TUpdate(AppUser entity)
        {

            _userDal.Update(entity);
        }
    }
}
