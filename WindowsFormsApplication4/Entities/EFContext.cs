using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4.Entities
{
   public class EFContext : DbContext
    {
        public EFContext() :base("ProductsActions")
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsImages> PrImages { get;  set; }       
    }
}
