using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Lab2Server.Models
{
    public class SageModel
    {
        [HiddenInput]
        public int Id { get; set;}

        [Required]
        public int Age { get; set; }

        [Required]
        public string Name { get; set; }

        public string City { get; set; }

        public string Photo { get; set; }
    }
}
