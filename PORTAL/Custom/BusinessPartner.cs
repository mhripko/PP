﻿using PORTAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PORTAL.Custom
{
    public class BusinessPartner
    {
        PIPESPORTALEntities db = new PIPESPORTALEntities();

        /// <summary>
        /// Returns the CompanyId key from a Contact
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public long GetCompanyIdFromContactLogin(string login)
        {
            long companyId = 0;
            
            return companyId;
        }
    }
}