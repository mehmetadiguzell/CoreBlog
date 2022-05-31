using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        void CommentAdd(Comment comment);
        //void BlogDelete(Comment comment);
        //void BlogUpdate(Comment comment);
        List<Comment> GetList(int id);
        //Comment GetById(int id);
        List<Comment> GetCommentListWithBlog();
    }
}
