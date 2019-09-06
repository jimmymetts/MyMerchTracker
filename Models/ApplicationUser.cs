using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyMerchTracker.Models

{
    public class ApplicationUser : IdentityUser

    {
        public ApplicationUser()
        { }
    
    [Required]
    [Display(Name="First Name")]
    public string FirstName { get; set; }

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    public virtual ICollection<Merch> Merchs { get; set; }

    }
}