using System.Web;

namespace Lab2Server.Models.api
{
    public class SaveBookModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }

        public int[] SelectedAuthorsIds { get; set; }
        public byte[] PhotoUpload { get; set; }
    }
}