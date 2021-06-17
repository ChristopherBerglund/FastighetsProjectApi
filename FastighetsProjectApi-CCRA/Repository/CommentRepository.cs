using FastighetsProjectApi_CCRA.Contracs;
using FastighetsProjectApi_CCRA.DTOmodel;
using FastighetsProjectApi_CCRA.HelpClasses;
using FastighetsProjectApi_CCRA.Model;
using Microsoft.AspNetCore.Mvc;
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
        public DbContext _Context { get; }

        public CommentRepository(DbContext Context)
            : base(Context)
        {
            _Context = Context;
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


        public CommentDTO GetCommenten(Comment comment) => new CommentDTO(comment);

        void ICommentRepository.CreateComment(Comment comment) => Create(comment);

        void ICommentRepository.DeleteComment(Comment comment)
        {
            Delete(comment);
        }

        IEnumerable<Comment> ICommentRepository.GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(x => ids.Contains(x.GuidID), trackChanges) //GUID?
                .ToList();


        public IEnumerable<Comment> GetCommentsTS(int id, SkipTakeParameters skipTakeParameters)
        {
            return  _dbContext.Comments.Where(c => c.RealEstateIde == id).OrderByDescending(d => d.CreatedOn).Skip(skipTakeParameters.skip).Take(skipTakeParameters.take).ToList();
            
        }

        public IEnumerable<CommentDTO> GetCommentsByUserTS(string username, SkipTakeParameters skipTakeParameters)
        {
            var comments =_dbContext.Comments.Where(c => c.UserName == username).OrderByDescending(d => d.CreatedOn).Skip(skipTakeParameters.skip).Take(skipTakeParameters.take).ToList();
            var commentsDTO = new List<CommentDTO>();
            foreach (var comment in comments)
            {
                commentsDTO.Add(new CommentDTO(comment));

            }
            return commentsDTO;
        }
    }
}


