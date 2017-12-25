namespace Lab2Server.Models.api
{
    public class DetailedBookModel
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public MultiSelectModel[] Authors { get; set; }

        public class MultiSelectModel
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }
    }
}