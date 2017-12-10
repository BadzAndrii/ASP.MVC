using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Lab2Server.Models
{
    public class BookModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MinLength(5), MaxLength(500)]
        public string Description { get; set; }

        [Required, Range(1900, 2017)]
        public int Year { get; set; }

        public string Authors { get; set; }

        [UIHint("_PhotoPreview")]
        public string Photo { get; set; }
    }
}
