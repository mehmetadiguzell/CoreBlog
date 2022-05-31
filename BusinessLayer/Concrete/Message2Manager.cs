using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class Message2Manager : IMessage2Service
    {
        IMessage2Dal _messageDal;

        public Message2Manager(IMessage2Dal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message2> GetList()
        {
            return _messageDal.GetAll();
        }

        public List<Message2> GetInboxListByWriter(int id)
        {
            return _messageDal.GetInBoxWithMessageByWriter(id);
        }

        public void TAdd(Message2 entity)
        {
            _messageDal.Add(entity);
        }

        public void TDelete(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public Message2 TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public void TUpdate(Message2 entity)
        {
            throw new NotImplementedException();
        }

        public List<Message2> GetSendBoxListByWriter(int id)
        {
            return _messageDal.GetSendBoxWithMessageByWriter(id);
        }
    }
}
