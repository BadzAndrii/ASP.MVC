using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2Server.Entities
{
    [Table("Sages")]
    public class Sage: KeyEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }

        public byte[] Photo { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
