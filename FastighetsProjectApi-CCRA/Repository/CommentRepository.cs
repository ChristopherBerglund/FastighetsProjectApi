using FastighetsProjectApi_CCRA.Contracs;
using FastighetsProjectApi_CCRA.DTOmodel;
using FastighetsProjectApi_CCRA.Model;
using Microsoft.EntityFrameworkCore;
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

        public List<Comment> GetCommentSkipTake(int id, int skip, int take)
        {
            var comments = new List<Comment>();
            if (skip == null && take == null)
            {
                Console.WriteLine("GetCommentSkipTake Failed");
                comments = _dbContext.Comments.Where(c => c.RealEstateIde == id).OrderByDescending(d => d.CreatedOn).ToList();
                    return comments;
            }
            else 
            {
                Console.WriteLine("GetCommentSkipTake Failed");
                comments = _dbContext.Comments.Where(c => c.RealEstateIde == id).OrderByDescending(d => d.CreatedOn).Skip((int)skip).Take((int)take).ToList();
                return comments;
            }
            
            return comments;

        }
        //public List<Comment> GetCommentSkipTake(int id)
        //{

        //    var comments = _dbContext.Comments.Where(c => c.RealEstateIde == id).OrderByDescending(d => d.CreatedOn).ToList();

        //    return comments;
        //}

        public CommentDTO GetCommenten(Comment comment) => new CommentDTO(comment);

        void ICommentRepository.CreateComment(Comment comment) => Create(comment);

        void ICommentRepository.DeleteComment(Comment comment)
        {
            Delete(comment);
        }

        IEnumerable<Comment> ICommentRepository.GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.GuidID), trackChanges) //GUID?
                .ToList();
    }
}


