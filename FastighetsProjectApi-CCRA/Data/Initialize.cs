using FastighetsProjectApi_CCRA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.Data
{
    public class Initialize
    {
        public static void Initializer(DbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Comments.Any())
            {

                return;
            }

            var user = new User[]
            {
                new User
                {
                    ID = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    UserId = "hejj",
                    UserName = "börje",
                    RealEstates  = 2,
                    Comments = 1,
                    Rating = 4

                },

                new User
                {
                    ID = new Guid("c9d4c053-49b6-410c-bc78-2d54a999187c"),
                    UserId = "hallå",
                    UserName = "börje",
                    RealEstates = 3,
                    Comments = 2,
                    Rating = 5
                }
            };


            context.Users.AddRange(user);
            context.SaveChanges();

            ////////////////////////////////////////////////
            
            var realestate = new RealEstate[]
            {
                new RealEstate
                {
                  Contact = "nils",
                  CreatedOn = new DateTime(2020 - 10 - 12),
                  ConstructionYear = 1710,
                  Address = "hallalundavägen 12",
                  Type = 2,
                  Description = "lägenhetshus",
                  Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991780"),
                  ide = 1,
                  Title = "titel1",
                  SellingPrice = 120000,
                  CanBeRented = false,
                  CanBeSold = true,
                  UserName = "björn",
                  RealestateType = "lägenhetshus",

                },

                new RealEstate
                {
                  Contact = "maria",
                  CreatedOn = new DateTime(2020 - 10 - 14),
                  ConstructionYear = 1850,
                  Address = "hamburgarevägen 12",
                  Type = 3,
                  Description = "lagerlokal",
                  Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991799"),
                  ide = 2,
                  Title = "titel2",
                  SellingPrice = 2000000,
                  CanBeRented = false,
                  CanBeSold = true,
                  UserName = "nisse",
                  RealestateType = "lagerlokal"
                }
            };


            context.RealEstates.AddRange(realestate);
            context.SaveChanges();

            //////////////////////////////////

            var comment = new Comment[]
            {
                new Comment
                {
                    GuidID = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991798"),
                        id = 5,
                        RealEstateId = 1,
                        Content = "superbra",
                        UserName = "björn",
                        CreatedOn = new DateTime(2020 - 12 - 13)

                },

                new Comment
                {
                        GuidID = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991797"),
                        id = 6,
                        RealEstateId = 2,
                        Content = "superbra men jättedåligt",
                        UserName = "nisse",
                        CreatedOn = new DateTime(2020 - 12 - 14)

                } 
            };


            context.Comments.AddRange(comment);
            context.SaveChanges();

        }
    }
}
