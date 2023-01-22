using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPratic.DAL
{
   public class ProductFeature
    {

        [Key,ForeignKey("Product")]
        public int Id { get; set; }

        public int  Width { get; set; }

        public int Height { get; set; }

        public string Color { get; set; }

        // Id'yi hem primary hem foreignkey olarak kullan.
        // public int ProductId { get; set; } // Child olduğu için foreign key 


        //Data a.  =  [ForeignKey("ProductId")] 
        public Product Product { get; set; }  //Child
    }
}
