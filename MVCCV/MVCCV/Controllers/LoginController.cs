using MVCCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCCV.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
		// GET: Login

		[HttpGet]
        public ActionResult Index()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Index(TBLADMIN a)
		{
            CVEntities db = new CVEntities();
            var userinfo = db.TBLADMIN.FirstOrDefault(x=> x.USERNAME == a.USERNAME && x.PASSWORD == a.PASSWORD);
            if(userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.USERNAME, false);
                Session["USERNAME"] = userinfo.USERNAME.ToString();
				return RedirectToAction("Index","Experience");
			}
            else
            {
				return RedirectToAction("Index", "Login");
			}
			
		}
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
			return RedirectToAction("Index", "Login");
		}
	}
}