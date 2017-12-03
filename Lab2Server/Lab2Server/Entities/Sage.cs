using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Server
{
    [Table("Sages")]
    public class Sage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }

        public byte[] Photo { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
