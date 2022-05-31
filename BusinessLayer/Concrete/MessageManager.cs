using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetList()
        {
            return _messageDal.GetAll();
        }

        public List<Message> GetInboxListByWriter(string p)
        {
            return _messageDal.GetAll(m => m.Recevier == p);
        }

        public void TAdd(Message entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Message entity)
        {
            throw new NotImplementedException();
        }

        public Message TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
