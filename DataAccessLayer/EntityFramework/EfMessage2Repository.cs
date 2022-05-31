using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {

        public List<Message2> GetInBoxWithMessageByWriter(int id)
        {
            using (Context db = new Context())
            {
                return db.Messages2.Include(m => m.SenderUser).Where(x => x.RecevierID == id).ToList();
            }
        }

        public List<Message2> GetSendBoxWithMessageByWriter(int id)
        {
            using (Context db = new Context())
            {
                return db.Messages2.Include(m => m.RecevierUser).Where(x => x.SenderID == id).ToList();
            }
        }
    }
}
