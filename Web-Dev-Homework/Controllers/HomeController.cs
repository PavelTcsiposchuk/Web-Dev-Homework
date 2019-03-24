using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Dev_Homework.Models;

namespace Web_Dev_Homework.Controllers
{
    public class HomeController : Controller
    {
        private static List<Bet> Bets = new List<Bet>();//i don`t see sense use a db, in this testproject isn`t necessary
        private BetInfoForFile RequestWriteObj;
        static HomeController()
        {
            Bet b1 = new Bet() { Id = 1, NameFighter = "Norris1", Rate = 2000 };
            Bet b2 = new Bet() { Id = 2, NameFighter = "Norris2", Rate = 2200 };
            Bet b3 = new Bet() { Id = 3, NameFighter = "Norris3", Rate = 2300 };
            Bets.Add(b1);
            Bets.Add(b2);
            Bets.Add(b3);


        }
        public ActionResult Index()
        {
            RequestWriteObj = new BetInfoForFile(Server.HtmlEncode(Request.RequestType), GetIPAddress(), Request.Url.ToString());
            ViewBag.Bets = Bets;
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
           
            RequestWriteObj = new BetInfoForFile(Server.HtmlEncode(Request.RequestType), GetIPAddress(), Request.Url.ToString());
            Bets.Remove(Bets.Find(b => b.Id == id));
            ViewBag.Bets = Bets;
            return View("~/Views/Home/Index.cshtml");
        }
        [HttpPut]
        public FilePathResult SaveFile()
        {

            RequestWriteObj = new BetInfoForFile(Server.HtmlEncode(Request.RequestType), GetIPAddress(), Request.Url.ToString());
            
            ViewBag.Bets = Bets;
            return 
        }
        [HttpPost]
        public ActionResult Add(Bet bet)
        {
            
            RequestWriteObj = new BetInfoForFile(Server.HtmlEncode(Request.RequestType), GetIPAddress(), Request.Url.ToString());
            if(Bets.Find(b => b == bet)== null)
                Bets.Add(bet);
            ViewBag.Bets = Bets;
            return View("~/Views/Home/Index.cshtml");
        }
        protected string GetIPAddress()//from Request.UserHostAddress i always received "::1", that`s way i found this function, then i understood that it was normal 
        {
            var context = System.Web.HttpContext.Current;
            string ip = String.Empty;

            if (context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            else if (!String.IsNullOrWhiteSpace(context.Request.UserHostAddress))
                ip = context.Request.UserHostAddress;

            if (ip == "::1")
                ip = "127.0.0.1";

            return ip;
        }
    }
}