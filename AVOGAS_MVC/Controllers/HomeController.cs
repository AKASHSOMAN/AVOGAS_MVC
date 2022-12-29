using Antlr.Runtime.Misc;
using AVOGAS_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AVOGAS_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Welcome to login page...";

            return View();
        }

        public ActionResult Registration()
        {
            ViewBag.Message = "Claim your place in us!";

            return View();
        }
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Welcome to your place";

            return View();
            
        }


        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                Avogas_Model model = new Avogas_Model();
                string firstname = frm["txtFirst"];
                string lastname = frm["txtLast"];
                string aadhaar = frm["txtAadhaar"];
                string mobile = frm["txtMobile"];
                string password = frm["txtPassw"];
                int status = model.InsertCustomer(firstname, lastname, aadhaar, mobile, password);
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        /// Redirect to Login view, if invalid credentials 
        ///

        public ActionResult Index1()
        {

            return View("Login");
        }
        /// Login process
        
        public ActionResult LoginCust(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                Avogas_Model model = new Avogas_Model();
                string name = frm["txtUser"];
                string passw = frm["txtPassw"];

                DataTable dt = model.UserLogin(name, passw);
                if (dt.Rows.Count > 0)
                    return RedirectToAction("Dashboard");
                else
                    return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Index1");
            }
        }
    }
}