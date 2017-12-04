using System.ComponentModel.DataAnnotations;

namespace Lab2Server.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required,MinLength(6)]
        public string Password { get; set; }
        [Required,MinLength(5)]
        public string Email { get; set; }
    }
}