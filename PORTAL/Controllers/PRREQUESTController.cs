﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using PORTAL.Models;
using PORTAL.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using Newtonsoft.Json;

namespace PORTAL.Controllers
{
    public class PRREQUESTController : Controller
    {
        private PIPESPORTALEntities db = new PIPESPORTALEntities();
        private string _pipesApiBaseUrl = ConfigurationManager.AppSettings["PipesApiBaseUrl"].ToString();

        // GET: PRREQUEST
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult MyProjects_Read([DataSourceRequest]DataSourceRequest request, long? contactId = 0, long? projectId = 0, string pf = "PR")
        {
            if ((long)contactId == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // This is your web api call...
            string uri = string.Format("http://localhost:2932/api/contacts/{0}/projects/{1}", contactId, projectId);
            var client = new RestClient();
            client.BaseUrl = new Uri(uri);
            var apiRequest = new RestRequest(uri, Method.GET);
            IRestResponse response = client.Execute(apiRequest);
            List<spForPortal_GetMyProjectsByContact_Result> mps = JsonConvert.DeserializeObject<List<spForPortal_GetMyProjectsByContact_Result>>(response.Content);

            mps = mps.Where(f => f.PLANSREQUIRED == true).ToList();
            
            DataSourceResult result = mps.ToDataSourceResult(request);

            return Json(result);
        }


        /// <summary>
        /// ProjectPlans_Read is called by a Kendo UI Grid to read the rows.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult ProjectPlans_Read([DataSourceRequest]DataSourceRequest request, long? id = 0)
        {
            if ((long)id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            string uri = string.Format("http://localhost:2932/api/projectplans/{0}", id);
            var client = new RestClient();
            client.BaseUrl = new Uri(uri);
            var apiRequest = new RestRequest(uri, Method.GET);
            IRestResponse response = client.Execute(apiRequest);
            List<spForPortal_GetProjectPlans_Result> pps = JsonConvert.DeserializeObject<List<spForPortal_GetProjectPlans_Result>>(response.Content);

            DataSourceResult result = pps.ToDataSourceResult(request);

            return Json(result);
        }


        

        // GET: PRREQUEST
        public ActionResult Create()
        {
            return View(new PlanReviewRequestViewModel()
            {
                ProjectNumber = "18.001",
                ProjectName = "Raider Stadium",
                PDFFILE = "18-001-01-01.PDF"
            }
            );
        }

        // POST: PRREQUEST/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsPlanReviewRequest", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ProjectNumber", System.Data.SqlDbType.VarChar).Value = collection["ProjectNumber"].ToString();
                        cmd.Parameters.Add("@ProjectName", System.Data.SqlDbType.VarChar).Value = collection["ProjectName"].ToString();
                        cmd.Parameters.Add("@PDFFILE", System.Data.SqlDbType.VarChar).Value = collection["PDFFILE"].ToString();
                        cmd.Parameters.Add("@REQUEST_BY", System.Data.SqlDbType.VarChar).Value = "bpuser@lvp.com";
                        cmd.Parameters.Add("@REQUEST_DT", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
                        con.Open();
                        cmd.ExecuteNonQuery();

                        CreatePRRequestEmail(collection);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Error Try Again...");

            // If we got this far, something failed, redisplay form
            return View();
        }


        /// <summary>
        /// Save the file upload
        /// </summary>
        /// <param name="attachments"></param>
        /// <returns></returns>
        public ActionResult Save(IEnumerable<HttpPostedFileBase> attachments)
        {
            //The Name of the Upload component is "attachments".
            foreach (var file in attachments)
            {
                //Some browsers send file names with a full path. You only care about the file name.
                var fileName = Path.GetFileName(file.FileName);
                var destinationPath = Path.Combine(Server.MapPath("~/App_Data"), fileName);

                file.SaveAs(destinationPath);
            }

            //Return an empty string to signify success.
            return Content("");
        }

        /// <summary>
        /// CreatePRRequestEmail sends to the Development Services Group that a new Plan Review request has been submitted.
        /// </summary>
        /// <param name="FormCollection collection">A collection of form fields.</param>
        protected void CreatePRRequestEmail(FormCollection collection)
        {
            string[] recipientList = { ConfigurationManager.AppSettings["PlanReviewRequestNotifyList"].ToString() };
            string senderEmail = ConfigurationManager.AppSettings["returnEmailAddress"].ToString();
            string subject = "PIPES Portal -> A New Plan Review Request has been submitted!";
            string body = "A new Plan Review Request for the PIPES project: <br /><br />" +
            "Description : " + collection["ProjectNumber"].ToString() + "<br /><br />" +
            "ParcelNumber: " + collection["ProjectName"].ToString() + "<br /><br />" +
            "PDF File Name: " + collection["PDFFILE"].ToString() + "<br /><br />" +
            "Please inspect and take appropriate action - Thank You";

            EMail emailToSend = new EMail();
            if (!emailToSend.SendEMail(subject,
             body,
             null,                  // To
             null,                  // CC
             recipientList,    // BCC
             senderEmail))          // From
            {
                ViewBag.ErrorMsg = "ERROR: EMAIL WAS NOT SENT. Verify email addresses.";
                ViewBag.RedirectToProjectRecord = false;
                Redirect("~/Views/Shared/Error.cshtml");
            }
        }
    }
}
