using System.Web;

namespace Lab2Server.Models
{
    public class EditSageModel : SageModel
    {
        public HttpPostedFileBase PhotoUpload { get; set; }
    }
}