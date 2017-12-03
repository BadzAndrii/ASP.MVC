using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2Server
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }

        public byte[] Photo { get; set; }

        public virtual ICollection<Sage> Sages { get; set; }
    }
}
