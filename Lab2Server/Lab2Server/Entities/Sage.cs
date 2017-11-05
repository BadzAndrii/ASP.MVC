using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Server
{
    class Sage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        //public int Photo { get; set; }
        public int Age { get; set; }
        //public virtual List<Book> Book { get; set; }
        public virtual ICollection<Book> Book { get; set; }
    }
}
