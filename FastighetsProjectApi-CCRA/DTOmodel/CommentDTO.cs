using FastighetsProjectApi_CCRA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.DTOmodel
{
    public class CommentDTO 
    {
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }

        public CommentDTO(Comment comment)
        {
            this.Content = comment.Content;
            this.UserName = comment.UserName;
            this.CreatedOn = comment.CreatedOn;
        }
    }
}
