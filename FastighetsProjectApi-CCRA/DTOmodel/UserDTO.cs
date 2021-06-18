using FastighetsProjectApi_CCRA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.DTOmodel
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public int Realestates { get; set; }
        public int Comments { get; set; }
        public double Rating { get; set; }
        public UserDTO(User user)
        {
            UserName = user.UserName;
            Realestates = user.RealEstates;
            Comments = user.Comments;
            Rating = user.Rating;
        }
    }
}
