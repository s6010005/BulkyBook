using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Κατηγορία")]
        public string Name { get; set; }
        [DisplayName("Σειρά")]
        [Range(1, 100, ErrorMessage = "Από το 1 εως το 100!")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now; 
    }
}
