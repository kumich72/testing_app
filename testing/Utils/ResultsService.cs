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
    }

    public static class ResultsService
    {
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


    }
}