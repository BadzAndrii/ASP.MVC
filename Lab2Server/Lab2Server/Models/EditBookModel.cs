using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Lab2Server.Models
{
    public class EditBookModel : BookModel
    {
        [Required]
        public new MultiSelectList Authors { get; set; }

        public HttpPostedFileBase PhotoUpload { get; set; }
    }
}