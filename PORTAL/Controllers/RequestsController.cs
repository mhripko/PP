﻿using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PORTAL.Models;
using Kendo.Mvc.Extensions;

namespace PORTAL.Controllers
{
    public class RequestsController : Controller
    {
        private PIPESPORTALEntities db = new PIPESPORTALEntities();

        // GET: Requests
        public ActionResult Index()
        {
            return View();
        }


        //public ActionResult GetContacts_Read([DataSourceRequest]DataSourceRequest request)
        //{
        //    List<sp_GetAllContacts_Result> pcr = db.sp_GetAllContacts().ToList();

        //    DataSourceResult result = pcr.ToDataSourceResult(request);

        //    return Json(result);
        //}
    }
}