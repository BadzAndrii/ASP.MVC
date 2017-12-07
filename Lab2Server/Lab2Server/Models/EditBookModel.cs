using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Lab2Server.Models
{
    public class EditBookModel : BookModel
    {
        [Required]
        [UIHint("MultiSelect")]
        public new MultiSelectList Authors { get; set; }

        [UIHint("UploadPhoto")]
        public HttpPostedFileBase PhotoUpload { get; set; }
    }
}