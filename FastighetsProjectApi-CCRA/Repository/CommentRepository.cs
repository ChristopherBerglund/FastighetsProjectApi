using FastighetsProjectApi_CCRA.Contracs;
using FastighetsProjectApi_CCRA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.Repository
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(DbContext Context)
            : base(Context)
        {

        }

        public IEnumerable<Comment> GetAllComment(bool trackChanges)
        {
            return FindAll(trackChanges)
                    .OrderBy(c => c.UserName)
                    .ToList();
        }

        public Comment GetComment(Guid inId, bool trackChanges) =>
            FindByCondition(c => c.id.Equals(inId), trackChanges)
            .SingleOrDefault();

        void ICommentRepository.CreateComment(Comment comment) => Create(comment);

        void ICommentRepository.DeleteComment(Comment comment)
        {
            Delete(comment);
        }

        IEnumerable<Comment> ICommentRepository.GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.ID), trackChanges) //GUID?
                .ToList();
    }
}


