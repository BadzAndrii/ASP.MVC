using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Lab2Server.Models
{
    public class EditSageModel : SageModel
    {
        
        [UIHint("_PhotoUpload")]
        [Display(AutoGenerateField = false, Name = "Photo Upload")]
        public HttpPostedFileBase PhotoUpload { get; set; }
    }
}