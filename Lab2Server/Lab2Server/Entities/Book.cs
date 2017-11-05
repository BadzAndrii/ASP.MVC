using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Server
{
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        //public virtual List<Sage> Sage { get; set; }
        public virtual ICollection<Sage> Sage { get; set; }
    }
}
