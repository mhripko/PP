using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using PORTAL.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PORTAL.Controllers
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

        public ActionResult TermsOfUse()
        {
            ViewBag.Message = "Terms Of Use.";

            return View();
        }

        /// <summary>
        /// Dashboard shows the Dashboard view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Dashboard()
        {
            var currentUser = GetCurrentUser();
            
            if ((long)currentUser.CompanyId == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if ((long)currentUser.ContactId == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            // CompanyId
            ViewData["CID"] = currentUser.CompanyId;

            // ContactId
            ViewData["CONTACTID"] = currentUser.ContactId;

            //ViewData["UCCP"] = false;
            // Check whatever to see if User Can Create Project - AOA
            ViewData["UCCP"] = true;

            return View();
        }

        /// <summary>
        /// GetCompanyId returns the logged-in user's CompanyId from their Identity record.
        /// </summary>
        /// <returns>a long/big int representing the CompanyId for the logged in user.</returns>
        private long? GetCompanyId()
        {
            long? id;
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            long companyId = currentUser.CompanyId;
            long contactId = currentUser.ContactId;
            id = companyId;
            return id;
        }

        private ApplicationUser GetCurrentUser()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            return currentUser;
        }
    }
}