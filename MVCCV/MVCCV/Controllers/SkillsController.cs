using MVCCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Repositories;

namespace MVCCV.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills

        GenericRepository<TBLSKILLS> repo = new GenericRepository<TBLSKILLS>();

		public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }

		[HttpGet]
		public ActionResult AddSkill()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddSkill(TBLSKILLS p)
		{
			repo.Tadd(p);
			return RedirectToAction("Index");
		}
		public ActionResult DeleteSkill(int id)
		{
			var t = repo.Find(x => x.ID == id);
			repo.Tdelete(t);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult BringSkill(int id)
		{
			TBLSKILLS t = repo.Find(x => x.ID == id);
			return View(t);
		}
		[HttpPost]
		public ActionResult BringSkill(TBLSKILLS p)
		{
			TBLSKILLS t = repo.Find(x => x.ID == p.ID);
			t.SKILL=p.SKILL;
			t.PROGRESS = p.PROGRESS;
			repo.Tupdate(t);
			return RedirectToAction("Index");
		}
	}
}