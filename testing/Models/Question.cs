using System.ComponentModel.DataAnnotations.Schema;

namespace testing.Models
{
    [Table("Question")]
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Test Test { get; set; }
    }
}