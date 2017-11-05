using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2Server
{
    [Table("Books")]
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }

        public byte[] Photo { get; set; }

        public virtual ICollection<Sage> Sage { get; set; }
    }
}
