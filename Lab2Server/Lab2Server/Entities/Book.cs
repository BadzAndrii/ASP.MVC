using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2Server.Entities
{
    [Table("Books")]
    public class Book : KeyEntity
    {
        public Book()
        {
            Sages = new List<Sage>(0);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }

        public byte[] Photo { get; set; }

        public virtual ICollection<Sage> Sages { get; set; }
    }
}
