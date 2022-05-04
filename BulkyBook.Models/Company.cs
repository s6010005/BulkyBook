using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Εταιρεία")]
        public string Name { get; set; }
        public string? Email { get; set; }
        [DisplayName("Διεύθυνση")]
        public string? StreetAddress { get; set; }
        [DisplayName("Πόλη")]
        public string? City { get; set; }
        [DisplayName("Τ.Κ.")]
        public string? PostalCode { get; set; }
        [DisplayName("Κινητό")]
        public string? PhoneNumberMobile { get; set; }
        [DisplayName("Σταθερό")]
        public string? PhoneNumber { get; set; }
        [DisplayName("Ημερομηνία εγγραφής")]
        public DateTime? RegistrationDate { get; set; } = DateTime.Now;
        [DisplayName("ΑΦΜ")]
        public int? TIN { get; set; }
    }
}
