using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Lab2Server.Models
{
    public class EditBookModel : BookModel
    {
        [UIHint("_MultiSelect")]
        [Display(AutoGenerateField = false)]
        public new MultiSelectList Authors { get; set; }

        public int[] SelectedAuthorsIds { get; set; }

        [UIHint("_PhotoUpload")]
        [Display(AutoGenerateField = false, Name = "Photo Upload")]
        public HttpPostedFileBase PhotoUpload { get; set; }
    }
}