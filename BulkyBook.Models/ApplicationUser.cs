using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        [DisplayName("Όνομα")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Επώνυμο")]
        public string LastName { get; set; }
        [DisplayName("Διεύθυνση")]
        public string? StreetAddress { get; set; }
        [DisplayName("Πόλη")]
        public string? City { get; set; }

        [DisplayName("Τ.Κ.")]
        public string? PostalCode { get; set; }
        [DisplayName("Τηλέφωνο2")]
        public string? PhoneNumber2 { get; set; }
        //public int? CompanyId { get; set; }
        //[ForeignKey("CompanyId")]
        //[ValidateNever]
        //public Company Company { get; set; }
    }

}
