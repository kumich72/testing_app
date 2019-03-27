using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testing.Models;

namespace testing.Utils
{
    public class ResultDto
    {
        public string Number { get; set; }
        public int CountRight { get; set; }
        public int CountWrong { get; set; }
        public string Error { get; set; }
    }

    public class ResultQuery
    {
        public bool IsSuccessful { get; set; }
        public string Error { get; set; }
    }


    public static class ResultsService
    {
        private static NLog.Logger Nlogger = NLog.LogManager.GetCurrentClassLogger();

        public static IList<ResultDto> GetReport()
        {
            UserContext db = new UserContext();

            IList<ResultDto> result = new List<ResultDto>();
            IList<Result> resultsAll = db.Results.ToList();

            IList<Question> questionsList = db.Question.ToList();
            var number = 0;
            foreach(var question in questionsList)
            {
                number++;

                var resultRightCount = db.Results.Where(p => p.Question.Id == question.Id && p.ResultAnswer > 0).Count();

                var resultWrongCount = db.Results.Where(p => p.Question.Id == question.Id && p.ResultAnswer == 0).Count();

                var dto = new ResultDto {Number = number.ToString(), CountRight = resultRightCount, CountWrong = resultWrongCount };

                result.Add(dto);
            }
            if (result.Count > 0)
            {
                return result;
            }
            return null;
        }

        internal static ResultQuery AddAnswer(string value, string login)
        {
            var result = new ResultQuery { Error = "", IsSuccessful = true };
            try
            {
                var valueList = value.Split('_');
                using (UserContext db = new UserContext())
                {
                    var findUser= db.User.Where(p => p.Login == login).FirstOrDefault();
                    int answerId = Convert.ToInt32(valueList[1]);
                    int questionId = Convert.ToInt32(valueList[0]);
                    var answerFind = db.Answers.Where(p => p.Id == answerId).FirstOrDefault();
                    int resultAnswer = answerFind.IsRight ? 1 : 0;
                    var questionFind = db.Question.Where(p => p.Id == questionId).FirstOrDefault();
                    Result resultNew = new Result { Name = valueList[2], Date = DateTime.Now.ToShortDateString(), User = findUser ,
                        Answer = answerFind, Question = questionFind, ResultAnswer = resultAnswer};
                    db.Results.Add(resultNew);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Error = "При добавлении ответа возникла ошибка!value = " + value + "; login = " + login + "; " + ex.Message;
                result.IsSuccessful = false;
                Nlogger.Error("При добавлении ответа возникла ошибка! value=" + value + ";login=" + login + ";" + ex.Message + ";" + ex.InnerException);
            }
            return result;
        }

        internal static bool IsAnswerRight(string value)
        {
            try
            {
                var valueList = value.Split('_');
                using (UserContext db = new UserContext())
                {
                    int answerId = Convert.ToInt32(valueList[1]);
                    var answerFind = db.Answers.Where(p => p.Id == answerId).FirstOrDefault();
                    if (answerFind.IsRight)
                        return true;
                }
            }
            catch (Exception ex)
            {
                Nlogger.Error("При IsAnswerRight возникла ошибка! value=" + value + ";" + ex.Message + ";" + ex.InnerException);
            }
            return false;
            
        }
    }
}