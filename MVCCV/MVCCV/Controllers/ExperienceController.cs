using MVCCV.Models.Entity;
using MVCCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCV.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();
		public ActionResult Index()
        {
            var values=repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
		public ActionResult AddExperience(TBLEXPERIENCE p)
		{
			repo.Tadd(p);
            return RedirectToAction("Index");
		}

		public ActionResult DeleteExperience(int id)
		{
			TBLEXPERIENCE t = repo.Find(x => x.ID == id);
            repo.Tdelete(t);
            return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult BringExperience(int id)
        {
			TBLEXPERIENCE t = repo.Find(x => x.ID == id);
			return View(t);
		}
		[HttpPost]
		public ActionResult BringExperience(TBLEXPERIENCE p)
		{
			TBLEXPERIENCE t = repo.Find(x => x.ID == p.ID);
			t.TITLE = p.TITLE;
			t.SUBTITLE = p.SUBTITLE;
			t.DATE = p.DATE;
			t.DESCRIPTION = p.DESCRIPTION;
			repo.Tupdate(t);
			return RedirectToAction("Index");
		}
	}
}