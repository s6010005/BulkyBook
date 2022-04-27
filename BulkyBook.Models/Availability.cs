using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Availability
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Διαθεσιμότητα")]
        public string Name { get; set; }

    }
}
