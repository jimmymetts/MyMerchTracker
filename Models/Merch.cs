using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyMerchTracker.Models
{

    public class Merch
    {
        [Key]
        public int MerchId { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }


        [Required]
        public int Title { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, 10000.00, ErrorMessage= "The Price of {0} must be less than{2}.")]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string UserId { get; set; }

        //public string ImagePath { get; set; }

        //public bool Active { get; set; }

        //[Required]
        //public ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Merch Type")]
        public int MerchTypeId { get; set; }



    }
}

