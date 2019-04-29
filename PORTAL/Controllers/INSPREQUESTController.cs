﻿using RestSharp;
using RestSharp.Authenticators;
using Kendo.Mvc.Extensions;
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
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PORTAL.Controllers
{
    public class INSPREQUESTController : Controller
    {
        private PIPESPORTALEntities db = new PIPESPORTALEntities();
                
        // Project Status LOOKUP Entries
        private static long ProjINSPOnHoldStatusID = LookUpId.PROJECTSTATUS.Where(l => l.VALUE.Trim() == "INSPHOLD").FirstOrDefault().PDBLOOKUPID;
        private static long ProjClosedStatusID = LookUpId.PROJECTSTATUS.Where(l => l.VALUE.Trim() == "CLOSED").FirstOrDefault().PDBLOOKUPID;

        private static long InspectionAssetProjectID = LookUpId.INSPECTIONASSET.Where(l => l.VALUE.Trim() == "PROJECT").FirstOrDefault().PDBLOOKUPID;
        private static long InspectionAssetManholeID = LookUpId.INSPECTIONASSET.Where(l => l.VALUE.Trim() == "MANHOLE").FirstOrDefault().PDBLOOKUPID;
        private static long InspectionAssetPipeID = LookUpId.INSPECTIONASSET.Where(l => l.VALUE.Trim() == "PIPE").FirstOrDefault().PDBLOOKUPID;

        private static long InspWorkFlowApprovedID = LookUpId.INSPWORKFLOWSTATUS.Where(l => l.VALUE.Trim() == "APPROVED").FirstOrDefault().PDBLOOKUPID;


        // Inspection Status LOOKUP Entries
        private static long readyToScheduleInspStatusID = LookUpId.INSPECTIONSTATUS.Where(l => l.VALUE.Trim() == "READYTOSCHEDULE").FirstOrDefault().PDBLOOKUPID;
        private static long scheduledInspStatusID = LookUpId.INSPECTIONSTATUS.Where(l => l.VALUE.Trim() == "SCHEDULED").FirstOrDefault().PDBLOOKUPID;
        private static long rescheduledInspStatusID = LookUpId.INSPECTIONSTATUS.Where(l => l.VALUE.Trim() == "RESCHEDULE").FirstOrDefault().PDBLOOKUPID;
        private static long inProgInspStatusID = LookUpId.INSPECTIONSTATUS.Where(l => l.VALUE.Trim() == "INPROG").FirstOrDefault().PDBLOOKUPID;
        private static long notReqedInspStatusID = LookUpId.INSPECTIONSTATUS.Where(l => l.VALUE.Trim() == "NOTREQUESTED").FirstOrDefault().PDBLOOKUPID;
        private static long completedInspStatusID = LookUpId.INSPECTIONSTATUS.Where(l => l.VALUE.Trim() == "COMPLETED").FirstOrDefault().PDBLOOKUPID;
        private static long cancelledInspStatusID = LookUpId.INSPECTIONSTATUS.Where(l => l.VALUE.Trim() == "CANCELLED").FirstOrDefault().PDBLOOKUPID;

        // Inspection Type LOOKUP Entries
        private static long JSInspTypeID = LookUpId.INSPECTIONTYPE.Where(l => l.VALUE.Trim() == "JOBSTART").FirstOrDefault().PDBLOOKUPID;
        private static long FMInspTypeID = LookUpId.INSPECTIONTYPE.Where(l => l.VALUE.Trim() == "FIELDI").FirstOrDefault().PDBLOOKUPID;
        private static long PSInspTypeID = LookUpId.INSPECTIONTYPE.Where(l => l.VALUE.Trim() == "PSI").FirstOrDefault().PDBLOOKUPID;
        private static long COOInspTypeID = LookUpId.INSPECTIONTYPE.Where(l => l.VALUE.Trim() == "COOI").FirstOrDefault().PDBLOOKUPID;
        private static long FInspTypeID = LookUpId.INSPECTIONTYPE.Where(l => l.VALUE.Trim() == "FIPI").FirstOrDefault().PDBLOOKUPID;
        private static long BRInspTypeID = LookUpId.INSPECTIONTYPE.Where(l => l.VALUE.Trim() == "BNDI").FirstOrDefault().PDBLOOKUPID;

        // PROJECT Inspection Status LOOKUP Entries
        private static long ProjInspStatusReadyForJSID = LookUpId.PROJINSPSTATUS.Where(l => l.VALUE.Trim() == "READYFORJS").FirstOrDefault().PDBLOOKUPID;
        private static long ProjInspStatusUnderwayID = LookUpId.PROJINSPSTATUS.Where(l => l.VALUE.Trim() == "UNDERWAY").FirstOrDefault().PDBLOOKUPID;
        private static long ProjInspStatusOnHoldID = LookUpId.PROJINSPSTATUS.Where(l => l.VALUE.Trim() == "ONHOLD").FirstOrDefault().PDBLOOKUPID;
        private static long ProjInspStatusFinalComplID = LookUpId.PROJINSPSTATUS.Where(l => l.VALUE.Trim() == "FINALCOMPL").FirstOrDefault().PDBLOOKUPID;
        private static long ProjInspStatusFinalUnderwayID = LookUpId.PROJINSPSTATUS.Where(l => l.VALUE.Trim() == "FINALUNDERWAY").FirstOrDefault().PDBLOOKUPID;
        private static long ProjInspStatusBondRelUnderwayID = LookUpId.PROJINSPSTATUS.Where(l => l.VALUE.Trim() == "BONDRELUNDERWAY").FirstOrDefault().PDBLOOKUPID;
        private static long ProjInspStatusCompletedID = LookUpId.PROJINSPSTATUS.Where(l => l.VALUE.Trim() == "COMPLETED").FirstOrDefault().PDBLOOKUPID;


        // Inspection Result (DISPOSITION) Status LOOKUP Entries
        private static long inspectionResultPendingDispID = LookUpId.INSPECTIONRESULT.Where(l => l.VALUE.Trim() == "RESPEND").FirstOrDefault().PDBLOOKUPID;
        private static long inspectionPartialPassDispID = LookUpId.INSPECTIONRESULT.Where(l => l.VALUE.Trim() == "PARTPASS").FirstOrDefault().PDBLOOKUPID;
        private static long inspectionPassDispID = LookUpId.INSPECTIONRESULT.Where(l => l.VALUE.Trim() == "PASS").FirstOrDefault().PDBLOOKUPID;
        private static long inspectionFailDispID = LookUpId.INSPECTIONRESULT.Where(l => l.VALUE.Trim() == "FAIL").FirstOrDefault().PDBLOOKUPID;
        private static long inspectionNADispID = LookUpId.INSPECTIONRESULT.Where(l => l.VALUE.Trim() == "NA").FirstOrDefault().PDBLOOKUPID;
        private static long inspectionUndoneDispID = LookUpId.INSPECTIONRESULT.Where(l => l.VALUE.Trim() == "UNDONE").FirstOrDefault().PDBLOOKUPID;
        private static long inspectionInvalidateDispID = LookUpId.INSPECTIONRESULT.Where(l => l.VALUE.Trim() == "INVALIDATED").FirstOrDefault().PDBLOOKUPID;

        private static long ContractorBPTypeID = LookUpId.COMPANYTYPE.Where(l => l.VALUE.Trim() == "C").FirstOrDefault().PDBLOOKUPID;
        private static long DeveloperBPTypeID = LookUpId.COMPANYTYPE.Where(l => l.VALUE.Trim() == "D").FirstOrDefault().PDBLOOKUPID;
        private static long EngineerBPTypeID = LookUpId.COMPANYTYPE.Where(l => l.VALUE.Trim() == "E").FirstOrDefault().PDBLOOKUPID;

        // Inspection Request Status LOOKUP Entries
        private static long ACTIVEREQID = LookUpId.INSPREQSTATUS.Where(l => l.VALUE.Trim() == "ACTIVE").FirstOrDefault().PDBLOOKUPID;

        // Unassigned Inspector LOOKUP Entries
        private long unassignedInspectorID;


        // GET: INSPECTIONREQ
        public ActionResult Index()
        {
            //var iNSPECTIONREQS = db.INSPECTIONREQ.Include(i => i.CONTACT).Include(i => i.CONTACT1).Include(i => i.PROJECT).Include(i => i.LOOKUP).Include(i => i.LOOKUP1);
            //return View(iNSPECTIONREQS.ToList());
            return View();
        }

        public ActionResult MyProjects_Read([DataSourceRequest]DataSourceRequest request, long? contactId = 0, long? projectId = 0, string pf = "INSP")
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

            mps = mps.Where(f => f.InspsExempt == null).ToList();
            
            DataSourceResult result = mps.ToDataSourceResult(request);

            return Json(result);
        }


        // GET: INSPECTIONS/AtAGlance/5
        public ActionResult AtAGlance(long? id = 0)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // Check user can Request Inspections
            var currentUser = GetCurrentUser();
            long ContactID = currentUser.ContactId;
            long CompanyID = currentUser.CompanyId;

            bool userHasAccessToProject = db.USERPROJS.Where(c => (c.ProjectID == id) && (c.ContactID == ContactID) && (c.IS_ACTIVE)).FirstOrDefault() == null ? false : true;
            if (!userHasAccessToProject)
                return HttpNotFound();

            // This is your web api call...
            string uri = string.Format("http://localhost:2932/api/contacts/{0}/projects/{1}", ContactID, id);
            var client = new RestClient();
            client.BaseUrl = new Uri(uri);
            var apiRequest = new RestRequest(uri, Method.GET);
            IRestResponse response = client.Execute(apiRequest);
            List<spForPortal_GetMyProjectsByContact_Result> projects = JsonConvert.DeserializeObject<List<spForPortal_GetMyProjectsByContact_Result>>(response.Content);
            spForPortal_GetMyProjectsByContact_Result project = projects.FirstOrDefault();

            if (project == null)
                return HttpNotFound();

            loadProjectInfo(project);

            if (project.PIIIWFNUM == null)
            {
                ViewBag.ErrorMsg = "PROJECT INSPECTION INFO RECORD MISSING";
                ViewBag.RedirectToProjectRecord = true;
                return View("~/Views/Shared/Error.cshtml");
            }

            setInspAssetTypeVars();

            setInspDispositionVars();

            //List<sp_getProjUniqueInspections_Result> projUniqueInspections = db.sp_getProjUniqueInspections(pii.PROJECTID, pii.INSPWORKFLOW_NUM).ToList();
            //ViewData["upi"] = projUniqueInspections;
            //ViewData["upi_abbr"] = projUniqueInspections.OrderBy(x => x.inspAbbr).ToList();

            //List<sp_getProjInspAssets_Result> projInspAssets = db.sp_getProjInspAssets(pii.PROJECTID).ToList();
            //ViewData["projInspPIPEs"] = projInspAssets.Where(w => w.ASSETTYPEID == InspectionAssetPipeID).ToList();

            //ViewData["pipeInspActivityTable"] = db.sp_ProjPIPEInspActivitySpreadsheet(pii.PROJECTID, pii.INSPWORKFLOW_NUM).ToList();

            //ViewData["projInspMHs"] = projInspAssets.Where(w => w.ASSETTYPEID == InspectionAssetManholeID).ToList();

            //ViewData["mhInspActivityTable"] = db.sp_ProjMHInspActivitySpreadsheet(pii.PROJECTID, pii.INSPWORKFLOW_NUM).ToList();

            //ViewData["inspsNOTRequired"] = db.PROJINSPTEMPLATE
            //                                .Where(p => (p.PROJECTID == pii.PROJECTID)
            //                                            && (p.IS_ACTIVE)
            //                                            && (p.INSP_NOT_REQUIRED))
            //                                .ToList();


            //ViewData["DispLD"] = false;
            //ViewData["DispAtAGlance"] = true;
            //getCommentsAndDiscrepancies(project.PROJECTID);

            return View();
        }


        // GET: INSPECTIONREQ/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //INSPECTIONREQ inspReq = db.INSPECTIONREQ.Find(id);
            //if (inspReq == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(inspReq);
            return View();
        }

        //// GET: INSPECTIONREQ/Create
        //public ActionResult Create(long? id = 0)
        //{
        //    if (id == 0)
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        //    var currentUser = GetCurrentUser();
        //    long ContactID = currentUser.ContactId;

        //    bool userHasAccessToProject = db.USERPROJS.Where(c => (c.ProjectID == id) && (c.ContactID == ContactID) && (c.IS_ACTIVE)).FirstOrDefault() == null ? false : true;

        //    //spGetMyProjects_Result project = db.spGetMyProjects(ContactID, id).FirstOrDefault();

        //    // This is your web api call...
        //    string uri = string.Format("http://localhost:2932/api/contacts/{0}/projects/{1}", ContactID, id);
        //    var client = new RestClient();
        //    client.BaseUrl = new Uri(uri);
        //    var apiRequest = new RestRequest(uri, Method.GET);
        //    IRestResponse response = client.Execute(apiRequest);
        //    spForPortal_GetMyProjectsByContact_Result project = JsonConvert.DeserializeObject<spForPortal_GetMyProjectsByContact_Result>(response.Content);

        //    checkIfInspectionsToRequest((long) id, (long)project.PIIIWFNUM, InspectionAssetProjectID, (long)id, null, (int) project.NumPIAs, (long) project.PIIWKFLWSTATUSID);

        //    return View();
        //}



        // GET: INSPECTIONREQS/Create
        //
        //  ID      =   Project ID          =>  Record ID for Project of interest
        //
        public ActionResult Create(long? id = 0)
        {
            // Check user can Request Inspections
            var currentUser = GetCurrentUser();
            long ContactID = currentUser.ContactId;
            long CompanyID = currentUser.CompanyId;

            bool userHasAccessToProject = db.USERPROJS.Where(c => (c.ProjectID == id) && (c.ContactID == ContactID) && (c.IS_ACTIVE)).FirstOrDefault() == null ? false : true;
            if (!userHasAccessToProject)
                return HttpNotFound();

            // This is your web api call...
            string uri = string.Format("http://localhost:2932/api/contacts/{0}/projects/{1}", ContactID, id);
            var client = new RestClient();
            client.BaseUrl = new Uri(uri);
            var apiRequest = new RestRequest(uri, Method.GET);
            IRestResponse response = client.Execute(apiRequest);
            List<spForPortal_GetMyProjectsByContact_Result> projects = JsonConvert.DeserializeObject<List<spForPortal_GetMyProjectsByContact_Result>>(response.Content);
            spForPortal_GetMyProjectsByContact_Result project = projects.FirstOrDefault();

            if (project == null)
                return HttpNotFound();

            //setInspTypeVars();
            ViewData["FMInspTypeID"] = FMInspTypeID;
            ViewData["PSInspTypeID"] = PSInspTypeID;

            //setInspAssetTypeVars();

            //setInspStatusVars();

            //setInspDispositionVars();

            loadProjectInfo(project);

            // This is your web api call...
            uri = string.Format("http://localhost:2932/api/InspectionsToRequest/{0}", id);
            client = new RestClient();
            client.BaseUrl = new Uri(uri);
            apiRequest = new RestRequest(uri, Method.GET);
            response = client.Execute(apiRequest);
            List<sp_getProjInspToRequest_Result> nextInspections = JsonConvert.DeserializeObject<List<sp_getProjInspToRequest_Result>>(response.Content);

            // Correct the RedirectToAction (AOA)
            if ((nextInspections.Count() != 0) && (nextInspections.Where(i => i.INSPECTIONTYPEID == JSInspTypeID).FirstOrDefault() != null))
                return RedirectToAction("ReqJSInspection", new { PJID = id, PJPHID = 0 });

            // This is your web api call...
            uri = string.Format("http://localhost:2932/api/InspectionsByType/{0}?inspTypeId={1}&inspStatus={2}&inspDisp={3}&lastInspOnly={4}", id, FMInspTypeID, null, null, 1);
            client = new RestClient();
            client.BaseUrl = new Uri(uri);
            apiRequest = new RestRequest(uri, Method.GET);
            response = client.Execute(apiRequest);
            List<spGetProjInspByType_Result> fmis = JsonConvert.DeserializeObject< List<spGetProjInspByType_Result>>(response.Content);
            spGetProjInspByType_Result fmi = fmis.FirstOrDefault();
            //.ToList()
            //.OrderByDescending(o => o.INSPECTIONID).FirstOrDefault();

            // This is your web api call...
            uri = string.Format("http://localhost:2932/api/InspectionsByType/{0}?inspTypeId={1}&inspStatus={2}&inspDisp={3}&lastInspOnly={4}", id, PSInspTypeID, null, null, 1);
            client = new RestClient();
            client.BaseUrl = new Uri(uri);
            apiRequest = new RestRequest(uri, Method.GET);
            response = client.Execute(apiRequest);
            List<spGetProjInspByType_Result> psis = JsonConvert.DeserializeObject<List<spGetProjInspByType_Result>>(response.Content);
            //.ToList()
            //.OrderByDescending(o => o.INSPECTIONID).FirstOrDefault();
            spGetProjInspByType_Result psi = psis.FirstOrDefault();

            //////sp_getProjInspByType_Result cooi = db.sp_getProjInspByType(PJID, COOInspTypeID, null, null)
            //////                    .ToList()
            //////                    .OrderByDescending(o => o.INSPECTIONID).FirstOrDefault();

            ViewData["PIC"] = false;
            ViewData["nextInspectionsCount"] = nextInspections.Count();
            if (nextInspections.Count() == 0)
            {
                ViewData["PIC"] = false;
                if (project.PROJINSPSTATUSID == ProjInspStatusCompletedID)
                {
                    ViewData["PIC"] = true;
                    ViewData["AllProjRelatedInspsPass"] = true;

                    if ((fmi != null) && (fmi.DISPOSITIONID == inspectionResultPendingDispID))
                    {
                        ViewData["AllProjRelatedInspsPass"] = false;
                        ViewData["PIC"] = false;
                    }

                    if (project.PROJECTSTATUSID != ProjClosedStatusID)
                    {
                        ViewData["PIC"] = false;
                        ViewData["nextInspectionsCount"] = 1;
                    }
                    else
                        return View();
                }
            }

            loadProjectContactInfo(project.PROJECTID);

            //ViewData["firstNonJSReq "]= true;
            // Get the most recent Inspection Req (Updated_Dt desc)
            // This is your web api call...
            uri = string.Format("http://localhost:2932/api/FirstOrLastInspectionReq/{0}?lastInspOnly={1}", id, 1);
            client = new RestClient();
            client.BaseUrl = new Uri(uri);
            apiRequest = new RestRequest(uri, Method.GET);
            response = client.Execute(apiRequest);
            spGetFirstOrLastProjInspReq_Result lastReq = JsonConvert.DeserializeObject<spGetFirstOrLastProjInspReq_Result>(response.Content);
            List<spGetAllContactsForSearch_Result> companyContacts = db.spGetAllContactsForSearch(CompanyID).ToList();
            if (lastReq == null)
            {
                ViewData["callerNamesList"] = new SelectList(companyContacts.OrderBy(c => c.CONTACTNAME), "CONTACTID", "CONTACTNAME");
                ViewData["fieldNamesList"] = ViewData["callerNamesList"];
            }
            else
            {
                ViewData["callerNamesList"] = new SelectList(companyContacts.OrderBy(c => c.CONTACTNAME), "CONTACTID", "CONTACTNAME", lastReq.CALLERID);
                ViewData["fieldNamesList"] = new SelectList(ViewBag.callerNamesList, "Value", "Text", lastReq.FIELDCONTACTID);
                //ViewData["firstNonJSReq"] = false;
                ViewData["existingcallerId"] = lastReq.CALLERID;

                //spGetAllContactsForSearch_Result lastCaller = companyContacts.Where(c => (c.CONTACTID == lastReq.CALLERID)).FirstOrDefault();
                //if (lastCaller != null)
                //{
                //    ViewData["lastCallerName"] = lastCaller.CONTACTNAME;
                //    ViewData["lastCallerNumber"] = lastCaller.CONTACTPHONE;
                //    ViewData["lastCallerEmail"] = lastCaller.EMAIL;
                //}
                ViewData["lastCallerName"] = currentUser.FirstName + " " + currentUser.LastName;
                ViewData["lastCallerNumber"] = currentUser.PhoneNumber;
                ViewData["lastCallerEmail"] = currentUser.Email;


                spGetAllContactsForSearch_Result fieldContact = companyContacts.Where(c => (c.CONTACTID == lastReq.FIELDCONTACTID)).FirstOrDefault();
                if (fieldContact != null)
                {
                    ViewData["lastFieldContactName"]= fieldContact.CONTACTNAME;
                    ViewData["lastFieldCallerNumber"] = fieldContact.CONTACTPHONE;
                    ViewData["lastFieldCallerEmail"] = fieldContact.EMAIL;
                    ViewData["existingFieldContactId"] = lastReq.FIELDCONTACTID;
                }
            }

            //ViewData[workShift = new SelectList(db.LOOKUP.Where(l => l.FIELDTYPE == "WORKSHIFT"), "LOOKUPID", "DESCRIPTION");
            ViewData["workShift"] = new SelectList(LookUpId.WORKSHIFT, "PDBLOOKUPID", "DESCRIPTION");

            //////ViewData[assetTypeList = db.LOOKUP.Where(l => l.FIELDTYPE == "INSPECTIONASSET").ToList();

            //////ViewData[StateNames = States.getAllStateNames();

            ViewData["Project"] = project;

            ViewData["ProjPhaseId"] = 0;

            //////ViewData[ForSpecificAsset = FSA;

            //////ViewData[ForModalWindow = FMW;

            //////ViewData[AssetID = AID;

            //////ViewData[assetTypeID = ATID;
            //////ViewData[inspTypeID = ITID;

            ViewData["projectSelectedTab"] = "inspectionOptions";

            ViewData["nextInspections"] = nextInspections;

            // This is your web api call...
            uri = string.Format("http://localhost:2932/api/InspectionsNextToRequestDisplay/{0}", id);
            client = new RestClient();
            client.BaseUrl = new Uri(uri);
            apiRequest = new RestRequest(uri, Method.GET);
            response = client.Execute(apiRequest);
            List<sp_NextProjInspToReqDisplay_Result> nextInspectionsDisplay = JsonConvert.DeserializeObject<List<sp_NextProjInspToReqDisplay_Result>>(response.Content);
            bool FinalIsAvail = false;

            foreach (sp_NextProjInspToReqDisplay_Result nid in nextInspectionsDisplay)
            {
                if (nid.INSPECTIONTYPEID == FInspTypeID)
                {
                    FinalIsAvail = true;
                }
            }
            //////List<EASEMENTS> easements = db.EASEMENTS.Where(e => e.PROJECTID == PJID && e.IS_ACTIVE).ToList();

            //////bool isEasementComp = false;
            //////foreach (EASEMENTS em in easements)
            //////{
            //////    if (em.EASEMENT_REQUIRED == true)
            //////    {
            //////        if (em.EASEMENTS_MAP == true)
            //////        {
            //////            if (em.MAP_SIGNED != null && em.BOOKS != null && em.PAGE != null)
            //////            {
            //////                isEasementComp = true;
            //////            }
            //////            else
            //////            {
            //////                isEasementComp = false;
            //////            }
            //////        }
            //////        else
            //////        {
            //////            if (em.SURVEY_REVIEW != null && em.OK_FROM_SURVEY != null && em.DOC_NUM != null)
            //////            {
            //////                isEasementComp = true;
            //////            }
            //////            else
            //////            {
            //////                isEasementComp = false;
            //////            }
            //////        }
            //////    }
            //////}
            //////if (easements.Count() == 0)
            //////{
            //////    isEasementComp = true;
            //////}
            ViewData["FinalIsAvail"] = FinalIsAvail;
            //ViewData["isEasementComp"] = isEasementComp;

            // Check if Field Meet is available
            bool FMIsAvail = true;
            bool FMPending = false;
            if (fmi != null)
            {
                if ((fmi.INSPECTIONSTATUSID != completedInspStatusID) && (fmi.INSPECTIONSTATUSID != cancelledInspStatusID))
                {
                    FMIsAvail = false;
                    FMPending = true;
                }
                else if (fmi.DISPOSITIONID == inspectionResultPendingDispID)
                {
                    if ((fmi.INSPECTIONSTATUSID == inProgInspStatusID) && ((bool)ViewData["PIC"]))
                    {
                        ViewData["AllProjRelatedInspsPass"] = false;
                        ViewData["PIC"] = false;
                    }
                }
            }

            // Check if Project Status is available
            bool PSIsAvail = true;
            bool PSPending = false;
            if (psi != null)
            {
                if ((psi.INSPECTIONSTATUSID != completedInspStatusID) && (psi.INSPECTIONSTATUSID != cancelledInspStatusID))
                {
                    PSIsAvail = false;
                    PSPending = true;
                }
                else if (psi.DISPOSITIONID == inspectionResultPendingDispID)
                {
                    if ((psi.INSPECTIONSTATUSID == inProgInspStatusID) && ((bool)ViewData["PIC"]))
                    {
                        ViewData["AllProjRelatedInspsPass"] = false;
                        ViewData["PIC"] = false;
                    }
                }
            }

            //////bool InspReqForProjectAllowed = false;
            //////// Get the PROJECT INSPECTIONS INFORMATION Record (to check if Inspection Requests Allowed)
            //////// This means JOBSTART Inspection APPROVED and PASSED
            //////long InspWorkFlowAppr = LookUpId.INSPWORKFLOWSTATUS.Where(l => l.VALUE.Trim() == "APPROVED").FirstOrDefault().PDBLOOKUPID;
            //////PROJINSPINFO pii = (from l in db.PROJINSPINFO
            //////                    where ((l.PROJECTID == PJID) && (l.IS_ACTIVE) && (l.INSPWORKFLOW_STATUSID == InspWorkFlowAppr))
            //////                    select l).FirstOrDefault();

            ////////long InspCompletedID = LookUpId.INSPECTIONSTATUS.Where(l => l.VALUE.Trim() == "COMPLETED").FirstOrDefault().PDBLOOKUPID;

            //////if (pii != null)
            //////{
            //////    if ((pii.JOBSTART_STATUSID == completedInspStatusID) && (pii.JOBSTART_DT != null) && (pii.JOBSTART_DISPID == inspectionPassDispID) && (project.PROJECTSTATUSID != ProjINSPOnHoldStatusID))
            //////        InspReqForProjectAllowed = true;
            //////}

            //////// Check if Certification of Occupancy is available
            //////bool COOIsAvail = true;
            //////bool COOPending = false;
            //////List<CERTSOFOCC> nonApprovedLots = db.CERTSOFOCC.Where(l => l.PROJECTID == PJID && !l.IS_APPROVED && l.IS_ACTIVE).ToList();

            //////if (InspReqForProjectAllowed == false || nonApprovedLots.Count() == 0)
            //////{
            //////    COOIsAvail = false;
            //////}
            //////else if (cooi != null)
            //////{
            //////    if ((cooi.INSPECTIONSTATUSID != completedInspStatusID) && (cooi.INSPECTIONSTATUSID != cancelledStatusInspID))
            //////    {
            //////        COOIsAvail = false;
            //////        COOPending = true;
            //////    }
            //////    else if (cooi.DISPOSITIONID == inspectionResultPendingDispID)
            //////    {
            //////        if ((cooi.INSPECTIONSTATUSID == inProgInspStatusID) && ((bool)ViewData["PIC"]))
            //////        {
            //////            ViewData["AllProjRelatedInspsPass"] = false;
            //////            ViewData["PIC"] = false;
            //////        }
            //////    }
            //////}

            // Check inspection workflow number if PSI is available
            //////long iwfNum = (long)db.PROJINSPINFO.Where(p => p.PROJECTID == (long)PJID && p.IS_ACTIVE).FirstOrDefault().INSPWORKFLOW_NUM;
            //INSPWORKFLOWS iwfPS = db.INSPWORKFLOWS.Where(i => i.INSPWORKFLOW_NUM == iwfNum && i.INSPECTIONTYPEID == PSInspTypeID && i.IS_ACTIVE).FirstOrDefault();
            //if (iwfPS == null)
            //{
            ViewData["PSIsAvail"] = false;
            //}
            //else
            //{
            //    ViewData["PSIsAvail"] = PSIsAvail;
            //}

            ViewData["FMIsAvail"] = FMIsAvail;

            //////// Check inspection workflow if COO is available
            //////INSPWORKFLOWS iwfCOO = db.INSPWORKFLOWS.Where(i => i.INSPWORKFLOW_NUM == iwfNum && i.INSPECTIONTYPEID == COOInspTypeID && i.IS_ACTIVE).FirstOrDefault();
            //////if (iwfCOO == null)
            //////{
            //////    ViewData["COOIsAvail"] = false;
            //////}
            //////else
            //////{
            //////    ViewData["COOIsAvail"] = COOIsAvail;
            //////}

            ViewData["OtherRequestedInspsPass"] = true;
            //if (FMPending || PSPending || COOPending)
            if (FMPending || PSPending)
            {
                ViewData["OtherRequestedInspsPass"] = false;
            }

            //////if ((bool)FSA)
            //////    nextInspectionsDisplay = nextInspectionsDisplay.Where(t => t.INSPECTIONTYPEID == ITID).ToList();

            ViewData["nextInspectionsDisplay"] = nextInspectionsDisplay;

            return View();
        }


        // INSPECTIONREQS/loadProjectContactInfo
        protected void loadProjectContactInfo(long projId)
        {
            ViewBag.contractor = null;
            ViewBag.contractorOfficeContact = null;
            ViewBag.contractorFieldContact = null;

            //COMPANIES contractor = (from c in db.COMPANIES
            //                        join pc in db.PROJCOMPANIES on c.COMPANYID equals pc.CompanyID
            //                        join p in db.PROJECTS on pc.ProjectID equals p.PROJECTID
            //                        where ((p.PROJECTID == project.PROJECTID) && (c.COMPANYTYPEID == companyTypeContractor) && (p.IS_ACTIVE))
            //                        select c).FirstOrDefault();
            // This is your web api call...
            string uri = string.Format("http://localhost:2932/api/GetProjectBPs/{0}?BPType={1}", projId, ContractorBPTypeID);
            var client = new RestClient();
            client.BaseUrl = new Uri(uri);
            var apiRequest = new RestRequest(uri, Method.GET);
            var response = client.Execute(apiRequest);
            //List<sp_NextProjInspToReqDisplay_Result> nextInspectionsDisplay = JsonConvert.DeserializeObject<List<sp_NextProjInspToReqDisplay_Result>>(response.Content);
            List<spGetProjBPs_Result> contractors = JsonConvert.DeserializeObject<List<spGetProjBPs_Result>>(response.Content);
            spGetProjBPs_Result contractor = contractors.FirstOrDefault();

            if (contractor != null)
            {
                ViewBag.contractor = contractor;

                //long callerContactTypeId = (from l in db.LOOKUP
                //                            where l.FIELDTYPE == "CONTACTTYPE" && l.VALUE == "CALLER"
                //                            select l.LOOKUPID).FirstOrDefault();
                //long callerContactTypeId = LookUpId.CONTACTTYPE.Where(l => l.VALUE.Trim() == "CALLER").FirstOrDefault().PDBLOOKUPID;

                //    CONTACTS contractorOfficeContact = (from c in db.CONTACTS
                //                                        join pc in db.PROJCONTACTS on c.CONTACTID equals pc.ContactID
                //                                        where ((c.CONTACTTYPEID == callerContactTypeId) && (pc.ProjectID == project.PROJECTID) && (pc.IS_ACTIVE))
                //                                        select c).FirstOrDefault();
                //    if (contractorOfficeContact != null)
                //        ViewBag.contractorOfficeContact = contractorOfficeContact;
            }
        }


        // POST: INSPECTIONREQ/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "INSPECTIONREQID,REQUESTSTATUSID,PROJECTID,REQUESTDATE,CALLERID,FIELDCONTACTID,FROM_DT,TO_DT,WORK_SHIFT,OT_STARTTIME,IS_ACTIVE,ADDED_BY,ADDED_DT,UPDATED_BY,UPDATED_DT")] INSPECTIONREQ inspReq)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //db.INSPECTIONREQ.Add(inspReq);
        //        //db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    //ViewBag.CALLERID = new SelectList(db.CONTACTS, "CONTACTID", "INTERNALUSERNAME", inspReq.CALLERID);
        //    //ViewBag.FIELDCONTACTID = new SelectList(db.CONTACTS, "CONTACTID", "INTERNALUSERNAME", inspReq.FIELDCONTACTID);
        //    //ViewBag.PROJECTID = new SelectList(db.PROJECTS, "PROJECTID", "PROJECTNUMBER", inspReq.PROJECTID);
        //    //ViewBag.REQUESTSTATUSID = new SelectList(db.LOOKUPs, "LOOKUPID", "FIELDTYPE", inspReq.REQUESTSTATUSID);
        //    //ViewBag.WORK_SHIFT = new SelectList(db.LOOKUPs, "LOOKUPID", "FIELDTYPE", inspReq.WORK_SHIFT);

        //    return View(inspReq);
        //}


        // POST: INSPECTIONREQS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REQUESTDATE,COMPANYID,FROM_DT")] INSPECTIONREQS inspectionreq, long ProjId)
        {
            if (ModelState.IsValid)
            {
                GetCurrentUser();      // Get current User Id + current Time

                // Get Caller Contact's ID (may be 0 if currently not-existent in system)
                long callerId = Convert.ToInt32(this.Request.Form["existingcallerId"]);

                // Get Field Contact's ID (may be 0 if currently not-existent in system)
                long FieldContactId = Convert.ToInt32(this.Request.Form["existingFieldContactId"]);

                //addInspectionContacts(inspectionreq.COMPANYID, ProjId, callerId, FieldContactId);

                ////setNewInspVars();

                ////setInspTypeVars();

                // Finish filling in new INSPECTIONREQ Record
                inspectionreq.PROJECTID = ProjId;
                inspectionreq.CALLERID = callerId;
                inspectionreq.FIELDCONTACTID = FieldContactId;

                inspectionreq.WORK_SHIFT = Convert.ToInt32(this.Request.Form["WORKSHIFT"]);

                inspectionreq.REQUESTSTATUSID = ACTIVEREQID;

                inspectionreq.IS_ACTIVE = true;
                //inspectionreq.ADDED_BY = inspectionreq.UPDATED_BY = userName;
                //inspectionreq.ADDED_DT = inspectionreq.UPDATED_DT = currDate;

                // Add the new INSPECTIONREQS Record
                //db.INSPECTIONREQS.Add(inspectionreq);

                //db.SaveChanges();

                bool checkvalue;
                long inspectionTypeID;
                long assetID;

                int numInspections = (from key in Request.Form.AllKeys where (key.Contains("ITID_")) select key).Count();
                var frmControls = (from key in Request.Form.AllKeys where (key.Contains("ITID_")) select key);
                string[] ks;
                foreach (string key in frmControls)
                {
                    //Req = Request.Form[key];
                    if (checkvalue = bool.Parse(Request.Form.GetValues(key)[0]))
                    {
                        ks = key.Split('_');
                        inspectionTypeID = Convert.ToInt64(ks[1]);
                        assetID = Convert.ToInt64(ks[3]); //Convert.ToInt64(key.Split('_')[3].ToString());

                        // Create a new INSPECTION (using information from newly created INSPECTIONREQS Record
                        //INSPECTIONS inspection = new INSPECTIONS()
                        //{
                        //    INSPECTIONSTATUSID = readyToScheduleInspStatusID,
                        //    INSPECTIONREQID = inspectionreq.INSPECTIONREQID,
                        //    INSPECTORID = unassignedInspectorID,
                        //    //INSPECTIONTYPEID = inspectionTypeID,
                        //    INSPECTIONTYPEID = Convert.ToInt64(ks[1]),
                        //    //ASSETID = ProjId,
                        //    ASSETID = Convert.ToInt64(ks[3]),
                        //    DISPOSITIONID = inspectionResultPendingDispID,
                        //    IS_ACTIVE = true,
                        //    ADDED_BY = userName,
                        //    UPDATED_BY = userName,
                        //    ADDED_DT = currDate,
                        //    UPDATED_DT = currDate
                        //};

                        //// Add the new INSPECTIONS Record
                        //db.INSPECTIONS.Add(inspection);
                        //db.SaveChanges();

                        // Create a record in the INSPECTION CHAIN OF CUSTODY Table

                        //INSPCHAINOFCUSTODY ipc = new INSPCHAINOFCUSTODY()
                        //{
                        //    InspectionID = inspection.INSPECTIONID,
                        //    CurrentLocationID = receivedInspQueueID,
                        //    ActionID = checkinInspActionID,
                        //    TransferredBy = userName,
                        //    Transfer_DT = currDate,
                        //    IS_ACTIVE = true,
                        //    ADDED_BY = userName,
                        //    UPDATED_BY = userName,
                        //    ADDED_DT = currDate,
                        //    UPDATED_DT = currDate
                        //};

                        //db.INSPCHAINOFCUSTODY.Add(ipc);

                        // To be completed when support for FINAL/BOND RELEASE Inspections supported by PORTAL
                        ////if ((inspection.INSPECTIONTYPEID == FInspTypeID) || (inspection.INSPECTIONTYPEID == BRInspTypeID))
                        ////{
                        ////    PROJINSPINFO PII = (from q in db.PROJINSPINFO
                        ////                        where (q.PROJECTID == ProjId) && (q.IS_ACTIVE)
                        ////                        select q).FirstOrDefault();

                        ////    if (inspection.INSPECTIONTYPEID == FInspTypeID)
                        ////    {
                        ////        PII.PROJINSPSTATUS = ProjInspStatusFinalUnderwayID;
                        ////        PII.FINALINSP_STATUSID = readyToScheduleInspStatusID;
                        ////        PII.FINALINSP_DISPID = inspectionResultPendingDispID;
                        ////    }
                        ////    else
                        ////    {
                        ////        PII.PROJINSPSTATUS = ProjInspStatusBondRelUnderwayID;
                        ////        PII.BONDRELINSP_STATUSID = readyToScheduleInspStatusID;
                        ////        PII.BONDRELINSP_DISPID = inspectionResultPendingDispID;
                        ////    }

                        ////    PII.UPDATED_BY = userName;
                        ////    PII.UPDATED_DT = currDate;
                        ////    db.Entry(PII).State = EntityState.Modified;

                        ////}

                        //db.SaveChanges();
                    }
                }


                // If available, save the Request Comments
                string comments = WebUtility.HtmlEncode(Request.Form["COMMENTS"]);
                if (comments != null && !(comments.Equals("")))
                    saveReqComments(inspectionreq.INSPECTIONREQID, comments);

                return RedirectToAction("AtAGlance", "INSPREQUEST", new { id = ProjId });
            }

            return View();
        }


        // INSPECTIONS/checkIfInspectionsToRequest
        protected void checkIfInspectionsToRequest(long ProjID, long IWFNUM, long AssetTypeID, long AssetID, long? InspTypeID, int NumPIAs, long? InspWKFLWApproved)
        {
            //ViewData["ReadyForFINALInspection"] = true;
            //ViewData["ReadyForBONDRELInspection"] = false;
            List<sp_getProjInspWorkflow_Result> ProjInspWorkflow = null;
            //List<sp_getProjInspWorkflow_Result> failingProjInspWorkflow = null;
            List<sp_getProjOOOInspections_Result> ProjOOOInsps = null;
            //List<sp_getProjOOOInspections_Result> failingProjOOOInsps = null;

            if (InspWKFLWApproved != null)
            {
                // Get the Workflow Inspections
                // This is your web api call...
                string uri = string.Format("http://localhost:2932/api/InspectionsProjectWorkflow/{0}", ProjID);
                var client = new RestClient();
                client.BaseUrl = new Uri(uri);
                var apiRequest = new RestRequest(uri, Method.GET);
                IRestResponse response = client.Execute(apiRequest);
                ProjInspWorkflow = JsonConvert.DeserializeObject<List<sp_getProjInspWorkflow_Result>>(response.Content);
                //ProjInspWorkflow = db.sp_getProjInspWorkflow(ProjID).ToList();

                // Get the Out-Of-Order Inspections
                uri = string.Format("http://localhost:2932/api/InspectionsProjectOOO/{0}", ProjID);
                client.BaseUrl = new Uri(uri);
                var apiRequest2 = new RestRequest(uri, Method.GET);
                IRestResponse response2 = client.Execute(apiRequest2);
                ProjOOOInsps = JsonConvert.DeserializeObject<List<sp_getProjOOOInspections_Result>>(response2.Content);
                //ProjOOOInsps = db.sp_getProjOOOInspections(ProjID).ToList();

                ////    long failedInspections = 0;
                //    //long WFFailedInspections = 0;
                //    //long NWFFailedInspections = 0;

                ////    if ((ProjInspWorkflow != null) && (ProjInspWorkflow.Count() > 0))
                ////    {
                ////        failingProjInspWorkflow = ProjInspWorkflow.Where(w => (w.DISPOSITIONID != inspectionPassDispID)
                ////                                            && (w.PIT_INSPECTIONTYPEID != FInspTypeID)
                ////                                            && (w.PIT_INSPECTIONTYPEID != BRInspTypeID)
                ////                                            && (!w.PIT_INSP_NOT_REQUIRED)).ToList();
                ////        failingProjOOOInsps = ProjOOOInsps.Where(w => ((w.DISPOSITIONID != inspectionPassDispID))
                ////                                                && (w.INSPECTIONSTATUSID != cancelledInspStatusID)).ToList();

                ////        //WFFailedInspections = failingProjInspWorkflow.Count();
                ////        //NWFFailedInspections = failingProjOOOInsps.Count();

                ////        failedInspections = ProjInspWorkflow.Where(w => (w.DISPOSITIONID != inspectionPassDispID)
                ////                                            && (w.PIT_INSPECTIONTYPEID != FInspTypeID)
                ////                                            && (w.PIT_INSPECTIONTYPEID != BRInspTypeID)
                ////                                            && (!w.PIT_INSP_NOT_REQUIRED)).Count()
                ////                            +
                ////                            ProjOOOInsps.Where(w => ((w.DISPOSITIONID != inspectionPassDispID)
                ////                                && (w.INSPECTIONSTATUSID != cancelledInspStatusID))).Count();

                ////        if (failedInspections > 0)
                ////            ViewData["ReadyForFINALInspection"] = false;
                ////        else if (ProjInspWorkflow.Where(w => (w.DISPOSITIONID == inspectionPassDispID)
                ////                                            && (w.PIT_INSPECTIONTYPEID == FInspTypeID)).Count() > 0)
                ////        {
                ////            ViewData["ReadyForFINALInspection"] = false;
                ////            ViewData["ReadyForBONDRELInspection"] = true;

                ////            if (ProjInspWorkflow.Where(w => (w.DISPOSITIONID == inspectionPassDispID)
                ////                                            && (w.PIT_INSPECTIONTYPEID == BRInspTypeID)).Count() > 0)
                ////                ViewData["ReadyForBONDRELInspection"] = false;
                ////        }
                ////    }
                ////    else
                ////        ViewData["ReadyForFINALInspection"] = false;
            }
            ////else
            ////    ViewData["ReadyForFINALInspection"] = false;


            //if (((bool)ViewBag.InspWKFLWApproved) && (ProjInspWorkflow.Count() > 0))
            //{
            //    if (NumPIAs > 0)
            //        checkProjectInspectionWorkflow(ProjID, ProjInspWorkflow, IWFNUM);
            ////    THIS part will not be supported if CPROUDFOOT indicates that FINAL/BOND RELEASE Inspections
            ////    WILL NOT be available for Request through PORTAL
            ////    else
            ////        checkNOAssetProjectInspectionWorkflow(ProjID, ProjInspWorkflow);
            //}


            List<sp_getProjInspWorkflowHoldPoints_Result> holdPoints = new List<sp_getProjInspWorkflowHoldPoints_Result>();
            string uri3 = string.Format("http://localhost:2932/api/sp_getProjInspWorkflowHoldPoints/?projId={0}&inspTypeId={1}&assetTypeId={2}&assetId={3}", ProjID, InspTypeID,AssetTypeID,AssetID);
            var client3 = new RestClient();
            client3.BaseUrl = new Uri(uri3);
            var apiRequest3 = new RestRequest(uri3, Method.GET);
            IRestResponse response3 = client3.Execute(apiRequest3);
            holdPoints = JsonConvert.DeserializeObject<List<sp_getProjInspWorkflowHoldPoints_Result>>(response3.Content);
            //List<sp_getProjInspWorkflowHoldPoints_Result> holdPoints = db.sp_getProjInspWorkflowHoldPoints(ProjID, InspTypeID, AssetTypeID, AssetID).ToList();

            long currHoldingPoint = 0;
            //long completedID = (long)db.sp_getLookupID("INSPECTIONSTATUS", "COMPLETED").FirstOrDefault();
            foreach (var hp in holdPoints)
            {
                if (hp.CompStatus == completedInspStatusID)
                {
                    currHoldingPoint = (long)hp.INSPECTIONTYPEID;
                    break;
                }
            }

            //List<sp_getNextProjInspToReq_Result> nextInspections = db.sp_getNextProjInspToReq(ProjID, currHoldingPoint, ProjID, InspectionAssetProjectID, (int)IWFNUM).ToList();
            //if (((nextInspections == null) || (nextInspections.Count == 0)) && ((ViewBag.InspReqForProjectAllowed != null) && (!ViewBag.InspReqForProjectAllowed)))
            //    ViewBag.InspReqForProjectAllowed = false;
        }


        // GET: INSPECTIONREQ/Edit/5
        //public ActionResult Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    INSPECTIONREQ inspReq = db.INSPECTIONREQ.Find(id);
        //    if (inspReq == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CALLERID = new SelectList(db.CONTACTS, "CONTACTID", "INTERNALUSERNAME", inspReq.CALLERID);
        //    ViewBag.FIELDCONTACTID = new SelectList(db.CONTACTS, "CONTACTID", "INTERNALUSERNAME", inspReq.FIELDCONTACTID);
        //    ViewBag.PROJECTID = new SelectList(db.PROJECTS, "PROJECTID", "PROJECTNUMBER", inspReq.PROJECTID);
        //    ViewBag.REQUESTSTATUSID = new SelectList(db.LOOKUPs, "LOOKUPID", "FIELDTYPE", inspReq.REQUESTSTATUSID);
        //    ViewBag.WORK_SHIFT = new SelectList(db.LOOKUPs, "LOOKUPID", "FIELDTYPE", inspReq.WORK_SHIFT);
        //    return View(inspReq);
        //}


        //// POST: INSPECTIONREQ/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "INSPECTIONREQID,REQUESTSTATUSID,PROJECTID,REQUESTDATE,CALLERID,FIELDCONTACTID,FROM_DT,TO_DT,WORK_SHIFT,OT_STARTTIME,IS_ACTIVE,ADDED_BY,ADDED_DT,UPDATED_BY,UPDATED_DT")] INSPECTIONREQ inspReq)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(inspReq).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CALLERID = new SelectList(db.CONTACTS, "CONTACTID", "INTERNALUSERNAME", inspReq.CALLERID);
        //    ViewBag.FIELDCONTACTID = new SelectList(db.CONTACTS, "CONTACTID", "INTERNALUSERNAME", inspReq.FIELDCONTACTID);
        //    ViewBag.PROJECTID = new SelectList(db.PROJECTS, "PROJECTID", "PROJECTNUMBER", inspReq.PROJECTID);
        //    ViewBag.REQUESTSTATUSID = new SelectList(db.LOOKUPs, "LOOKUPID", "FIELDTYPE", inspReq.REQUESTSTATUSID);
        //    ViewBag.WORK_SHIFT = new SelectList(db.LOOKUPs, "LOOKUPID", "FIELDTYPE", inspReq.WORK_SHIFT);
        //    return View(inspReq);
        //}


        //// GET: INSPECTIONREQ/Delete/5
        //public ActionResult Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    INSPECTIONREQ inspReq = db.INSPECTIONREQ.Find(id);
        //    if (inspReq == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(inspReq);
        //}


        //// POST: INSPECTIONREQ/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(long id)
        //{
        //    INSPECTIONREQ inspReq = db.INSPECTIONREQ.Find(id);
        //    db.INSPECTIONREQ.Remove(inspReq);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        private ApplicationUser GetCurrentUser()
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            return currentUser;
        }


        protected void loadProjectInfo(spForPortal_GetMyProjectsByContact_Result project)
        {
            ViewData["ProjId"] = project.PROJECTID;

            ViewData["ProjName"] = project.PROJECTNAME;

            ViewData["ProjNumber"] = project.PROJECTNUMBER;
        }


        // INSPECTIONREQS/saveReqComments
        protected void saveReqComments(long recordID, string comments)
        {
            //COMMENTS c = new COMMENTS();

            //c.IS_ACTIVE = true;

            //c.COMMENTTYPEID = LookUpId.COMMENTTYPE.Where(l => l.VALUE.Trim() == "INSPREQ").FirstOrDefault().LOOKUPID;

            //c.OWNERTYPEID = LookUpId.COMMDISCOWNER.Where(l => l.VALUE.Trim() == "INSPREQ").FirstOrDefault().LOOKUPID;
            //c.RECORDID = recordID;

            //c.CCWRDINTERNAL = false;

            //c.COMMENTS1 = comments;

            //c.ADDED_BY = userName;       // grab the userId
            //c.ADDED_DT = currDate;

            //c.UPDATED_BY = userName;     // grab the userId
            //c.UPDATED_DT = currDate;

            //db.COMMENTS.Add(c);

            //db.SaveChanges();
        }


        // INSPREQUEST/setInspAssetTypeVars
        // Function to Load variables that indicate Type of Asset
        protected void setInspAssetTypeVars()
        {
            // Get the ID for the LOOKUP Record for Inspection "NOT REQUESTED"
            ViewBag.InspectionAssetProjectID = InspectionAssetProjectID;
            ViewBag.InspectionAssetManholeID = InspectionAssetManholeID;
            ViewBag.InspectionAssetPipeID = InspectionAssetPipeID;

            //ViewBag.InspectionsForProjects = db.sp_getLookUpEntriesForInspByAsset(InspectionAssetProjectID).ToList();

            //ViewBag.InspectionsForManholes = db.sp_getLookUpEntriesForInspByAsset(InspectionAssetManholeID).ToList();

            //ViewBag.InspectionsForPipes = db.sp_getLookUpEntriesForInspByAsset(InspectionAssetPipeID).ToList();
        }


        protected void setInspDispositionVars()
        {
            ViewBag.inspectionResultPendingDispID = inspectionResultPendingDispID;

            ViewBag.inspectionInvalidateDispID = inspectionInvalidateDispID;

            ViewBag.inspectionUndoneDispID = inspectionUndoneDispID;

            ViewBag.inspectionPartialPassDispID = inspectionPartialPassDispID;

            ViewBag.inspectionPassDispID = inspectionPassDispID;

            ViewBag.inspectionFailDispID = inspectionFailDispID;

            ViewBag.inspectionNADispID = inspectionNADispID;

            //COMMENTTYPEID = LookUpId.COMMENTTYPE.Where(l => l.VALUE.Trim() == "INSPACTION").FirstOrDefault().LOOKUPID;

            //OWNERTYPEID = LookUpId.COMMDISCOWNER.Where(l => l.VALUE.Trim() == "INSPECTION").FirstOrDefault().LOOKUPID;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}