using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2Server
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
    }
}

