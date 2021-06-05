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
    }
}
