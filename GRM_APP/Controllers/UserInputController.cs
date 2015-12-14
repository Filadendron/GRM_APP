using GRM_APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GRM_APP.Controllers
{
    public class UserInputController : Controller
    {
        //
        // GET: /UserInput/
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Poruka="Unesi Korisnika";
            return View("UserInput");
        }

        [HttpPost]
        public ActionResult Index(string Name, string Surname,DateTime Birth_date, string Gender, string Email, string Password)
        {
            using (GeneralManager manager = new GeneralManager())
            {
                manager.AddUser(Name, Surname, Birth_date, Gender, Email,Password);
            }

            ViewBag.Poruka = "Uspjesno ste unijeli korisnika";

            return View("UserInput");
        }

    }
}
