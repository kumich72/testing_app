using System.Collections.Generic;

namespace testing.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Question Question { get; set; }
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