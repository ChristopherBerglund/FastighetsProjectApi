using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.Model
{
    public class User
    {
        public Guid ID { get; set; } //Testar
       
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int RealEstates { get; set; }
        public int Comments { get; set; }
        public double Rating { get; set; }
        public string AvatarImageUrl { get; set; }
        public int CounterRating { get; set; }
        public double TotalRatingSum { get; set; }

        public void RatingCalc(double rate)
        {

            CounterRating += 1;
            TotalRatingSum += rate;
            Rating = TotalRatingSum / CounterRating;

        }
    }
}
