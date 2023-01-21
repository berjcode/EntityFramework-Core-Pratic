using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPratic.DAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int stock { get; set; }


        public int CategoryId { get; set; }



        public Category Category { get; set; } //Navigation property
        public ProductFeature ProductFeature { get; set; } // 1-1 İLİŞKİ
    }
}
