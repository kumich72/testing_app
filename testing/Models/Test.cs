using System.ComponentModel.DataAnnotations.Schema;

namespace testing.Models
{
    [Table("Test")]
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}