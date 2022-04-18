using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BulkyBook.Models
{
    public class ProductBook
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Τίτλος")]
        public string Title { get; set; }
        [Display(Name = "Περιγραφή")]
        public string Description { get; set; }
        [Display(Name = "Ημερομηνία κυκλοφορίας")]
        public DateTime DatePublished { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        [Display(Name = "Συγγραφέας")]
        public string Author { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "List Price")]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 10000)]
        [Display(Name = "Τιμή για 1-10 τεμάχια")]
        public double Price { get; set; }

        [Required]
        [Range(1, 10000)]
        [Display(Name = "Τιμή για 20-50 τεμάχια")]
        public double Price20 { get; set; }

        [Required]
        [Range(1, 10000)]
        [Display(Name = "Τιμή για 50-100 τεμάχια")]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Τιμή για 100+ τεμάχια")]
        [Range(1, 10000)]
        public double Price100 { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Κατηγορία")]
        
        public int CategoryId { get; set; }
        //[ForeignKey("CategoryId")] not necessary
        [ValidateNever]
        public Category Category { get; set; }

        [Required]
        [Display(Name = "Τύπος εξωφύλλου")]
        
        public int CoverTypeId { get; set; }
        [ValidateNever]
        public CoverType CoverType { get; set; }

    }
}
