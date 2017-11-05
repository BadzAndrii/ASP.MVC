using System.Collections.Generic;

namespace Lab2Server.Models
{
    public class ListBookModels : BookModel
    {
        public ListBookModels()
        {
            Books = new List<BookModel>(0);
            ListAuthors = new Dictionary<int, string>(0);
        }

        // SAVE/CREATE
        public new List<int> Authors { get; set; }
        
        // PRE- !!!VIEW!!!
        public Dictionary<int,string> ListAuthors { get; private set; }

        // PRE- !!!VIEW!!!
        public List<BookModel> Books { get; private set; }
    }
}