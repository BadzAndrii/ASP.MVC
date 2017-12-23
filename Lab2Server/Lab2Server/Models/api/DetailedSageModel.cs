namespace Lab2Server.Models.api
{
    public class SageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string Photo { get; set; }
    }

    public class DetailedSageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string Photo { get; set; }


        public class MultiSelectModel
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }
    }
}