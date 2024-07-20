using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MVCCV.Models.Entity;
using MVCCV.Repositories;

namespace MVCCV.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        GenericRepository<TBLSOCIALMEDIA> repo = new GenericRepository<TBLSOCIALMEDIA>();


		public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
		[HttpPost]
		public ActionResult AddSocialMedia(TBLSOCIALMEDIA s)
		{
            repo.Tadd(s);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult BringSocialMedia(int id)
        {
            var page = repo.Find(x=> x.ID == id);
            return View(page);
        }
		[HttpPost]
		public ActionResult BringSocialMedia(TBLSOCIALMEDIA sm)
		{
			var page = repo.Find(x => x.ID == sm.ID);
            page.STATUS =true;
            page.ACCOUNT = sm.ACCOUNT;
            page.LINK = sm.LINK;
            page.ICON = sm.ICON;
            repo.Tupdate(page);
			return RedirectToAction("Index");
		}
		public ActionResult DeleteSocialMedia(int id)
        {
            var status = repo.Find(x => x.ID == id);
		    status.STATUS = false;
			repo.Tupdate(status);
			return RedirectToAction("Index");
		}
	}
}