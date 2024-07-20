using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;
namespace MVCCV.Controllers
{
    public class AdminController : Controller
    {
		// GET: Admin
		GenericRepository<TBLADMIN> repo = new GenericRepository<TBLADMIN>();
		public ActionResult Index()
        {
            var value = repo.List();
            return View(value);
        }
		[HttpGet]
		public ActionResult AddAdmin()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddAdmin(TBLADMIN p)
		{
			repo.Tadd(p);
			return RedirectToAction("Index");
		}

		public ActionResult DeleteAdmin(int id)
		{
			TBLADMIN t = repo.Find(x => x.ID == id);
			repo.Tdelete(t);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult BringAdmin(int id)
		{
			TBLADMIN t = repo.Find(x => x.ID == id);
			return View(t);
		}
		[HttpPost]
		public ActionResult BringAdmin(TBLADMIN p)
		{
			TBLADMIN t = repo.Find(x => x.ID == p.ID);
			t.USERNAME = p.USERNAME;
			t.PASSWORD = p.PASSWORD;
			repo.Tupdate(t);
			return RedirectToAction("Index");
		}
	}
}