using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace testing.Models
{
    [Table("Answers")]
    public class Answer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("Question_Id")]
        public Question Question { get; set; }
        [Column("IsRight")] 
        public bool IsRight { get; set; }
    }

    public class TestAnswersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuestionId { get; set; }
        public bool IsRight { get; set; }
    }

    public class TestQuestionsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TestAnswersDto> TestAnswersDto { get; set; }
    }

    public class TestCommonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TestQuestionsDto> TestQuestionsDto { get; set; }
    }
}