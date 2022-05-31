using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentdal;

        public CommentManager(ICommentDal commentdal)
        {
            _commentdal = commentdal;
        }
        public void CommentAdd(Comment comment)
        {
            _commentdal.Add(comment);
        }

        public List<Comment> GetCommentListWithBlog()
        {
            return _commentdal.GetCommentListWithBlog();
        }

        public List<Comment> GetList(int id = 0)
        {
            return _commentdal.GetAll(m => m.BlogID == id);
        }
    }
}
