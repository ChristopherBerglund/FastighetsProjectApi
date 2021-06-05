using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastighetsProjectApi_CCRA.Model
{
    public class RealEstate
    {
        public string ImageUrl { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string Contact { get; set; }
        public List<Comment> Comments { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime CreatedOn { get; set; }
        [Required(ErrorMessage = "Byggår är obligatorisk, mellan 1600-2025")]
        [Range(1600, 2025)]
        public int ConstructionYear { get; set; }
        [Required(ErrorMessage = "Address är obligatorisk.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Bostadstyp är obligatorisk.")]
        public int Type { get; set; }
        [Required(ErrorMessage = "Skriv en beskrivning av fastigheten, mellan 10 och 1000 tecken.")]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }
        [Required]
        public Guid Id { get; set; }
        [Key]
        public int ide { get; set; }
        [Required(ErrorMessage = "Skriv en titel.")]
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }
        public int? SellingPrice { get; set; }
        public int? RentingPrice { get; set; }
        public bool CanBeSold { get; set; }
        public bool CanBeRented { get; set; }
        public string UserName { get; set; }
        public string RealestateType { get; set; }

        public RealEstate()
        {
        }
        public enum EstateTypeEnum
        {
            Lägenhet = 1,
            Hus = 2,
            Kontor = 3,
            Lagerhus = 4
        }
        public RealEstate(string imageUrl, string address, int realEstateType, string title, int sellingPrice, int rentingPrice, bool canBeSold, bool canBeRented)
        {
            ImageUrl = imageUrl;
            Address = address;
            Type = realEstateType;
            Title = title;
            SellingPrice = sellingPrice;
            RentingPrice = rentingPrice;
            CanBeSold = canBeSold;
            CanBeRented = canBeRented;
        }
    }

}
