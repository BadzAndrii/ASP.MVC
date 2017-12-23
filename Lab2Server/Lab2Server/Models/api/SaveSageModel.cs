using System.Web;

namespace Lab2Server.Models.api
{
    public class SaveSageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }

        public byte[] PhotoUpload { get; set; }
    }
}