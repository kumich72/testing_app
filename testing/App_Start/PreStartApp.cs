using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testing.App_Start;
using testing.Models;
using testing.Utils;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(PreStartApp), "Start")]

namespace testing.App_Start
{

    public static class PreStartApp
    {
        private static NLog.Logger Nlogger = NLog.LogManager.GetCurrentClassLogger();
        const string RoleName = "student";
        public static void Start()
        {
            Nlogger.Info("Doing something in  PreStart");

            using (UserContext db = new UserContext())
            {
                var role = new Role { Name = RoleName };
                var findRole = db.Role.Where(p => p.Name == RoleName).FirstOrDefault();
                if (findRole == null)
                {

                    db.Role.Add(role);
                    db.SaveChanges();
                }
                //var userName = "Иванов Иван Иванович";

                //GenerateUser(db, role, userName, "ivanov_ii");

                var userName = "Тестов1 Тест Тестович";
                GenerateUser(db, role, userName, "testov1_tt");

                //GenerateResults(UserContext db, Answer answers, Question findQuestion, User user)


                userName = "Тестов2 Тест Тестович";
                GenerateUser(db, role, userName, "testov2_tt");
                
                userName = "Тестов3 Тест Тестович";
                GenerateUser(db, role, userName, "testov3_tt");

                userName = "Тестов4 Тест Тестович";
                GenerateUser(db, role, userName, "testov4_tt");

                userName = "Тестов5 Тест Тестович";
                GenerateUser(db, role, userName, "testov5_tt");
                //GenerateAnswers(db);

               // GenerateResults(db);
            }
        }

        private static void GenerateUser(UserContext db, Role role, string userName, string login)
        {
            var findUser = db.User.Where(p => p.Name == userName).FirstOrDefault();
            if (findUser == null)
            {
                User user1 = new User { Name = userName, Roles = role, Login = login };
                db.User.Add(user1);
                db.SaveChanges();
            }
        }

        private static void GenerateAnswers(UserContext db)
        {
            var findQuestion2 = db.Question.Where(p => p.Id == 2).FirstOrDefault();
            if (findQuestion2 != null)
            {
                Answer answers4 = new Answer { Name = "111000", IsRight = false, Question = findQuestion2 };
                Answer answers5 = new Answer { Name = "101010", IsRight = false, Question = findQuestion2 };
                Answer answers6 = new Answer { Name = "11011", IsRight = true, Question = findQuestion2 };
                db.Answers.Add(answers4);
                db.Answers.Add(answers5);
                db.Answers.Add(answers6);
                db.SaveChanges();
            }

            var findQuestion3 = db.Question.Where(p => p.Id == 3).FirstOrDefault();
            if (findQuestion3 != null)
            {
                Answer answers1 = new Answer { Name = "7 млрд.", IsRight = true, Question = findQuestion3 };
                Answer answers2 = new Answer { Name = "10 млрд.", IsRight = false, Question = findQuestion3 };
                Answer answers3 = new Answer { Name = "5млрд.", IsRight = false, Question = findQuestion3 };
                db.Answers.Add(answers1);
                db.Answers.Add(answers2);
                db.Answers.Add(answers3);
                db.SaveChanges();
            }

            var findQuestion4 = db.Question.Where(p => p.Id == 4).FirstOrDefault();
            if (findQuestion4 != null)
            {
                Answer answers1 = new Answer { Name = "Лермонтов", IsRight = false, Question = findQuestion4 };
                Answer answers2 = new Answer { Name = "Пушкин", IsRight = true, Question = findQuestion4 };
                Answer answers3 = new Answer { Name = "Некрасов", IsRight = false, Question = findQuestion4 };
                db.Answers.Add(answers1);
                db.Answers.Add(answers2);
                db.Answers.Add(answers3);
                db.SaveChanges();
            }

            var findQuestion5 = db.Question.Where(p => p.Id == 5).FirstOrDefault();
            if (findQuestion5 != null)
            {
                Answer answers1 = new Answer { Name = "6", IsRight = true, Question = findQuestion5 };
                Answer answers2 = new Answer { Name = "8", IsRight = false, Question = findQuestion5 };
                Answer answers3 = new Answer { Name = "12", IsRight = false, Question = findQuestion5 };
                db.Answers.Add(answers1);
                db.Answers.Add(answers2);
                db.Answers.Add(answers3);
                db.SaveChanges();
            }
        }

        private static void GenerateResults(UserContext db, Answer answers, Question findQuestion, User user)
        {

        }

        private static void GenerateResults(UserContext db)
        {
            var users = db.User.ToList();
            var questions = db.Question.ToList();
            var answers = db.Answers.ToList();
            var i = 0;
            foreach (User user in users)
            {
                foreach (Question question in questions)
                {
                    i++;

                    var allAnswers = db.Answers.Where(p => p.Question.Id == question.Id).ToList();
                    
                    Result result = new Result { Date = DateTime.Now.ToShortDateString(), Question = question, User = user, Answer = allAnswers.FirstOrDefault(), ResultAnswer = 0 , Name  = allAnswers.FirstOrDefault().Name };

                    if (allAnswers.FirstOrDefault().IsRight)
                    {
                        result.ResultAnswer = 1;
                    }
                    db.Results.Add(result);
                    db.SaveChanges();
                }
            }
            Nlogger.Info("Generate result DONE!");
        }
    }
}
