using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FastighetsProjectApi_CCRA.Model
{
    public class Comment
    {

        public Guid GuidID { get; set; }
        [Key]
        public int id { get; set; }
        [ForeignKey("RealEstateIde")]
        public int RealEstateIde { get; set; }
        [Required]
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; } 
        //public User User { get; set; } = new User();
        public Comment(string content)
        {
            Content = content;
            CreatedOn = DateTime.Now;
        }

        public Comment(int realEstateId, string content, string userName)
        {
            RealEstateIde = realEstateId;
            Content = content;
            UserName = userName;
            CreatedOn = DateTime.Now;
        }
        public Comment()
        {
            this.CreatedOn = DateTime.Now;
            this.GuidID = new Guid();
        }

        public override string ToString()
        {
            return Content + UserName + CreatedOn.ToString();
        }
    }
}