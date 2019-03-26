using DevExpress.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testing.Models;
using testing.Utils;

namespace testing.Controllers
{
    

    public class HomeController : Controller
    {

        

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestPage()
        {
            //id теста для выгрузки
            var id = 1;
            var results = TestsService.GetTest(id);
            ViewBag.test = results;
            return View();
        }

        [HttpPost]
        public ActionResult TestPage(FormCollection fc)
        {
            //id теста для выгрузки
            var id = 1;
            var countRight = 0;
            var countWrong = 0;
            foreach (var key in fc.AllKeys)
            {
                if(key.contain("rb"))
                {
                    var value = fc[key];    
                    var answerSave = ResultsService.AddAnswer(value, Session["Login"]);
                    var isAnswerRight  = ResultsService.IsAnswerRight(value);
                    if(isAnswerRight)
                    {
                        countRight++;
                    }else
                    {
                        countWrong++;
                    }
                }
            }

            //foreach (var key in fc.Keys)
            //{
              //  var value = fc[key.ToString()];
                // etc.
            //}
            //var results = TestsService.GetTest(id);
            //ViewBag.test = results;
            return View(id);
        }

        public ActionResult Register()
        {
            var newUser = new UserDto();
            return View(newUser);
        }

        [HttpPost]
        public ActionResult Register(UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                var suc = UserService.Create(userDto);
            }
            return View(userDto);
        }
        
        public ActionResult LoginIn()
        {
            string userName = (string)Session["UserName"];
            var newUser = new LoginDto();
            return View();
        }

        [HttpPost]
        public ActionResult LoginIn(LoginDto loginDto)
        {
            Session["Login"] = loginDto.Login;
            var suc = UserService.LoginIn(loginDto);
            if(suc.Succsess != true)
                Session["Login"] = null;
            return View(loginDto);
        }

        public ActionResult Report()
        {
            ViewBag.Message = "Отчет";

            var results = ResultsService.GetReport();

            results.FirstOrDefault().CountRight = 4;
            results.FirstOrDefault().CountWrong = 1;
            ViewBag.Results = results;
            
            return View();
        }



        public ActionResult ResultGraphic()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChartPartial()
        {
            var model = new object[0];
            return PartialView("_ChartPartial", model);
        }
    }
}
