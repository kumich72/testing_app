using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testing.Models;

namespace testing.Utils
{
    public class TestsService
    {
        public static TestCommonDto GetTest(int id)
        {
            using (UserContext db = new UserContext())
            {
                var testCommonDto = new TestCommonDto();
                var findTest = db.Test.Where(p => p.Id == id).FirstOrDefault();
                if(findTest!=null)
                {
                    testCommonDto.Id = findTest.Id;
                    testCommonDto.Name = findTest.Name;

                    var questionList = db.Question.Where(p => p.Test.Id == findTest.Id).ToList();

                    List<TestQuestionsDto> questionListDto = new List<TestQuestionsDto>();
                    foreach (var question in questionList)
                    {
                        TestQuestionsDto testQuestionsDto = new TestQuestionsDto();
                        testQuestionsDto.Id = question.Id;
                        testQuestionsDto.Name = question.Name;

                        List<TestAnswersDto> answersListDto = new List<TestAnswersDto>();
                        var answersList = db.Answers.Where(p => p.Question.Id == question.Id).ToList();
                        foreach (var answer in answersList)
                        {
                            TestAnswersDto testAnswersDto = new TestAnswersDto();
                            testAnswersDto.Id = answer.Id;
                            testAnswersDto.Name = answer.Name;

                            answersListDto.Add(testAnswersDto);
                        }
                        testQuestionsDto.TestAnswersDto = answersListDto;

                        questionListDto.Add(testQuestionsDto);
                    }
                    testCommonDto.TestQuestionsDto = questionListDto;
                    return testCommonDto;
                }
                return null;
            }
        }
    }
}