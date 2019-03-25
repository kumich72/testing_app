using System.ComponentModel.DataAnnotations;

namespace testing.Models
{
    public class LoginDto
    {
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool Succsess { get; set; }
        public string Error { get; set; } 
    }
}