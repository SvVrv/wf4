using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4.Entities
{
    [Table("tblProducts")]
   public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength:255)]
        public string Name { get; set; }
        public int Count { get; set; }
        [Required]
        public int Price { get; set; }
        public ICollection<ProductsImages> Images { get; set; }
    }
}
