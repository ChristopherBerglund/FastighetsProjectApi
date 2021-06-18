using FastighetsProjectApi_CCRA.DTOmodel;
using FastighetsProjectApi_CCRA.HelpClasses;
using FastighetsProjectApi_CCRA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.Contracs
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAllComment(bool trackChanges);
        Comment GetComment(Guid id, bool trackChanges);

        void CreateComment(Comment comment);
        IEnumerable<Comment> GetByIds(IEnumerable<Guid> ids, bool trackChanges); //?
        void DeleteComment(Comment comment);
        IEnumerable<CommentDTO> PostComment(Comment comment);

        IEnumerable<Comment> GetCommentsTS(int id, SkipTakeParameters skipTakeParameters);
        IEnumerable<CommentDTO> GetCommentsByUserTS(string username, SkipTakeParameters skipTakeParameters);
    }
}
