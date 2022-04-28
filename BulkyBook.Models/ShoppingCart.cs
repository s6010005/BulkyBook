using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class ShoppingCart
    {
        public ProductBook ProductBook { get; set; }
        public int Count { get; set; }
    }
}
