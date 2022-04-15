using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class CoverType
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Εξώφυλλο")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
