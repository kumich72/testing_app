using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace testing.Models
{
    [Table("Results")]
    public class Result
    {
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Question_Id")]
        public Question Question { get; set; }
        [Column("Answer_Id")]
        public Answer Answer { get; set; }
        [Column("User_Id")]
        public User User { get; set; }
        [Column("Date")]
        public string Date { get; set; }
        [Column("Result")]
        public int ResultAnswer { get; set; }
    }
}