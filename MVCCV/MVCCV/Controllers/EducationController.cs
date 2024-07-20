using MVCCV.Models.Entity;
using MVCCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCV.Controllers
{
    public class EducationController : Controller
    {
		// GET: Education
		GenericRepository<TBLEDUCATION> repo = new GenericRepository<TBLEDUCATION>();
		public ActionResult Index()
        {
            var values = repo.List();
            return View(values);
        }
		[HttpGet]
		public ActionResult AddEducation()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddEducation(TBLEDUCATION p)
		{
			if(!ModelState.IsValid)
			{
				return View("AddEducation");
			}
			repo.Tadd(p);
			return RedirectToAction("Index");
		}

		public ActionResult DeleteEducation(int id)
		{
			TBLEDUCATION t = repo.Find(x => x.ID == id);
			repo.Tdelete(t);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult BringEducation(int id)
		{
			TBLEDUCATION t = repo.Find(x => x.ID == id);
			return View(t);
		}
		[HttpPost]
		public ActionResult BringEducation(TBLEDUCATION p)
		{
			if (!ModelState.IsValid)
			{
				return View("BringEducation");
			}
			TBLEDUCATION t = repo.Find(x => x.ID == p.ID);
			t.TITLE = p.TITLE;
			t.SUBTITLE1 = p.SUBTITLE1;
			t.SUBTITLE2 = p.SUBTITLE2;
			t.DATE = p.DATE;
			t.GPA = p.GPA;
			repo.Tupdate(t);
			return RedirectToAction("Index");
		}
	}
}