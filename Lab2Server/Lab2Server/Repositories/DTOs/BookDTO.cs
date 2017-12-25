namespace Lab2Server.Repositories.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Authors { get; set; }
    }
}