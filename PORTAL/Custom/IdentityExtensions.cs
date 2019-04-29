using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace PORTAL.Custom
{
    public static class IdentityExtensions
    {
        /// <summary>
        /// GetCompanyId
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetCompanyId(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirstValue("CompanyId");
            }
            return null;
        }

        public static string GetFirstName(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirstValue("FirstName");
            }
            return null;
        }

        public static string GetLastName(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirstValue("LastName");
            }
            return null;
        }

        public static string GetMustChangePW(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirstValue("MustChangePW");
            }
            return null;
        }

    }
}