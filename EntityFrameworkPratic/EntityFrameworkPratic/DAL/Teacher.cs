using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPratic.DAL
{
    public class Teacher
    {

        public int  Id { get; set; }

        public string  Name { get; set; }


        //n-n aynısını diğer tarafta yap
        public List<Student>  Students { get; set; }
    }
}
