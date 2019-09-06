using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyMerchTracker.Models
{
    public class MerchType
    {
        [Key]
        public int Id { get; set; }

        public string label { get; set; }

        [NotMapped]
        public int Quantity { get; set; }

        public virtual ICollection<Merch> Merchs { get; set; }
    }

}

