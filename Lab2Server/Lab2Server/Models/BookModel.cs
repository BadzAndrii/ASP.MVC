using System;
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

        public string Description { get; set; }

        [Required]
        [UIHint("Date")]
        public int Year { get; set; }

        public string Authors { get; set; }

        [UIHint("PhotoPreview")]
        public string Photo { get; set; }
    }
}
