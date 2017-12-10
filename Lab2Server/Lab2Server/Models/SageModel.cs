using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Lab2Server.Models
{
    public class SageModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MinLength(2), MaxLength(500)]
        public string City { get; set; }

        [Required, Range(0, 115)]
        public int Age { get; set; }

        [UIHint("_PhotoPreview")]
        public string Photo { get; set; }
    }
}