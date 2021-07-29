using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MVCTask.Helpers;

namespace MVCTask.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Change(string language)
        {
            if (language == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Empty language");

            var culture = Language.TryCreateCulture(language);
            if (culture == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid language");

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // Update user language
            HttpCookie cookie = new HttpCookie(Language.Key)
            {
                Value = language
            };

            Response.Cookies.Add(cookie);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}