using MVCCV.Models.Entity;
using MVCCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCV.Controllers
{
	
    public class AboutController : Controller
    {
        // GET: About
	   GenericRepository<TBLABOUT> repo = new GenericRepository<TBLABOUT>();
		[HttpGet]
		public ActionResult Index()
		{
			var about = repo.List();
			return View(about);
		}
		[HttpPost]
		public ActionResult Index(TBLABOUT i)
		{
			var t = repo.Find(x => x.ID == 1);
			t.NAME = i.NAME;
			t.SURNAME = i.SURNAME;
			t.ADDRESS = i.ADDRESS;
			t.MAIL = i.MAIL;
			t.PHONENUMBER = i.PHONENUMBER;
			t.DESCRIPTION = i.DESCRIPTION;
			t.IMAGE = i.IMAGE;
			repo.Tupdate(t);
			return RedirectToAction("Index");
		}
	}
}