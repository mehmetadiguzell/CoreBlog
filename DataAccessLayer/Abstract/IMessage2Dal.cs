using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        List<Message2> GetInBoxWithMessageByWriter(int id);
        List<Message2> GetSendBoxWithMessageByWriter(int id);
    }
}
