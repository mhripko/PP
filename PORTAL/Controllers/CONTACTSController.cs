using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PORTAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PORTAL.Controllers
{
    public class CONTACTSController : Controller
    {
        private PIPESPORTALEntities db = new PIPESPORTALEntities();
        //private string _pipesApiBaseUrl = ConfigurationManager.AppSettings["PipesApiBaseUrl"].ToString();

        [Authorize(Roles = "PortalAdmin,PartnerAdmin")]
        // GET: CONTACTS
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "PortalAdmin,PartnerAdmin")]
        /// <summary>
        /// Index_Read is called by a Kendo UI Grid to read the rows.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult Index_Read([DataSourceRequest]DataSourceRequest request)
        {
            var currentUser = GetCurrentUser();
            ViewData["CONTACTID"] = currentUser.ContactId;
            ViewData["CID"] = currentUser.CompanyId;
            ViewData["IsLockedCID"] = true;
            if (User.IsInRole("PortalAdmin"))
            {
                ViewData["IsLockedCID"] = false;
            }

            long? companyId = 0;
            if (Convert.ToBoolean(ViewData["IsLockedCID"]))
            {
                companyId = currentUser.CompanyId;
            }
            else
            {
                companyId = null;
            }

            List<spGetAllContactsForSearch_Result> spCall = db.spGetAllContactsForSearch(companyId).ToList();
            DataSourceResult result = (spCall).ToDataSourceResult(request);
            return Json(result);
        }

        // GET: CONTACTS/Create
        [Authorize(Roles = "PortalAdmin,PartnerAdmin")]
        public ActionResult Create()
        {
            var currentUser = GetCurrentUser();
            ViewData["CONTACTID"] = currentUser.ContactId;
            ViewData["CID"] = currentUser.CompanyId;
            ViewData["IsLockedCID"] = true;
            if (User.IsInRole("PortalAdmin"))
            {
                ViewData["IsLockedCID"] = false;
            }

            long? companyId = 0;
            if (Convert.ToBoolean(ViewData["IsLockedCID"]))
            {
                companyId = currentUser.CompanyId;
            }
            else
            {
                companyId = null;
            }

            ViewBag.CONTACTTYPEID = new SelectList(db.PDBLOOKUP.Where(w => w.FIELDTYPE == "CONTACTTYPE"), "PDBLOOKUPID", "DESCRIPTION");
            return View();
        }

        // POST: CONTACTS/Create
        [Authorize(Roles = "PortalAdmin,PartnerAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CONTACTID,CONTACTTYPEID,INTERNALUSERNAME,CONTACTNAME,CONTACTPHONE,EXTENSION,EMAIL,COMPANYID")] CONTACTS cONTACTS)
        {
            if (ModelState.IsValid)
            {
                List<spInsertContact_Result> insContact = db.spInsertContact(
                    cONTACTS.CONTACTTYPEID,
                    cONTACTS.INTERNALUSERNAME,
                    cONTACTS.CONTACTNAME,
                    cONTACTS.CONTACTPHONE,
                    cONTACTS.EXTENSION,
                    cONTACTS.EMAIL,
                    cONTACTS.COMPANYID,
                    true,
                    cONTACTS.ADDED_BY,
                    System.DateTime.Now,
                    cONTACTS.UPDATED_BY,
                    System.DateTime.Now).ToList();
                    
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Error Try Again...");

            ViewBag.CONTACTTYPEID = new SelectList(db.PDBLOOKUP.Where(w => w.FIELDTYPE == "CONTACTTYPE"), "PDBLOOKUPID", "DESCRIPTION", cONTACTS.CONTACTTYPEID);
            return View(cONTACTS);
        }



        private ApplicationUser GetCurrentUser()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            return currentUser;
        }
    }
}