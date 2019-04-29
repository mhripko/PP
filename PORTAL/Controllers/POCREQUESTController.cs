using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;
using PORTAL.Custom;
using PORTAL.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PORTAL.Controllers
{
    public class POCREQUESTController : Controller
    {
        private PIPESPORTALEntities db = new PIPESPORTALEntities();
        private string _pipesApiBaseUrl = ConfigurationManager.AppSettings["PipesApiBaseUrl"].ToString();

        // GET: POCREQUEST
        public ActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// Index_Read is called by a Kendo UI Grid to read the rows.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult Index_Read([DataSourceRequest]DataSourceRequest request)
        {
            List<spGetAllPOCRequests_Result> pocr = db.spGetAllPOCRequests().ToList();
            DataSourceResult result = (pocr).ToDataSourceResult(request);
            return Json(result);
        }


        /// <summary>
        /// MyProjects_Read is called by a Kendo UI Grid to read the rows.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult MyPOCs_Read([DataSourceRequest]DataSourceRequest request, long? id = 0 )
        {
            if ((long) id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // This is your web api call...
            string uri = string.Format("http://localhost:2932/api/pocrequest/{0}", id);
            var client = new RestClient();
            client.BaseUrl = new Uri(uri);
            var apiRequest = new RestRequest(uri, Method.GET);
            IRestResponse response = client.Execute(apiRequest);
            List<spGetAllPOCRequests_Result> mps = JsonConvert.DeserializeObject<List<spGetAllPOCRequests_Result>>(response.Content);

            DataSourceResult result = mps.ToDataSourceResult(request);

            return Json(result);
        }


        // GET: POCREQUEST/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: POCREQUEST/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: POCREQUEST/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsPOCRequest", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ProjectDescription", System.Data.SqlDbType.VarChar).Value = collection["PROJECTDESC"].ToString();
                        cmd.Parameters.Add("@ParcelNumber", System.Data.SqlDbType.VarChar).Value = collection["ParcelNumber"].ToString();
                        cmd.Parameters.Add("@ERU", System.Data.SqlDbType.Float).Value = Convert.ToDouble(collection["ERU"]);
                        cmd.Parameters.Add("@QAVG", System.Data.SqlDbType.Decimal).Value = Convert.ToDouble(collection["QAVG"]);
                        cmd.Parameters.Add("@REQUEST_BY", System.Data.SqlDbType.VarChar).Value = "bpuser@lvp.com";
                        cmd.Parameters.Add("@REQUEST_DT", System.Data.SqlDbType.DateTime).Value = DateTime.Now;
                        con.Open();
                        cmd.ExecuteNonQuery();

                        CreatePOCRequestEmail(collection);

                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Error Try Again...");

            // If we got this far, something failed, redisplay form
            return View();
        }

        
        /// <summary>
        /// CreatePOCRequestEmail sends to the Modeling Team and Development Services Group that a new POC request has been submitted.
        /// </summary>
        /// <param name="contactEMail">A string represending the Contact EMail of the contact.</param>
        protected void CreatePOCRequestEmail(FormCollection collection)
        {
            string[] recipientList = { ConfigurationManager.AppSettings["POCRequestNotifyList"].ToString() };
            string senderEmail = ConfigurationManager.AppSettings["returnEmailAddress"].ToString();
            
            // ***
            // *** this version has more detail if they ever decided to send more detail ***
            // ***
            //string subject = "PIPES Portal -> A New POC Request has been submitted!";
            //string body = "A new POC Request with the description: <br /><br />" +
            //"Description : " + collection["PROJECTDESC"].ToString() + "<br /><br />" +
            //"ParcelNumber: " + collection["ParcelNumber"].ToString() + "<br /><br />" +
            //"ERU: " + collection["ERU"].ToString() + "<br /><br />" +
            //"QAVG: " + collection["QAVG"].ToString() + "<br /><br />" + 
            //"Please inspect and take appropriate action - Thank You";

            // From Heidi Martell email describing email notification templates 5/31/2018
            string subject = "POC Request";
            string body = "<br /><br />A point of connection (POC) request has been submitted.";

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


        // GET: POCREQUEST/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: POCREQUEST/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: POCREQUEST/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: POCREQUEST/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
