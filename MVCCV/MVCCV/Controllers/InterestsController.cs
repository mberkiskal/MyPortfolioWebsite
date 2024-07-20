using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;

namespace MVCCV.Controllers
{
    public class InterestsController : Controller
    {
        // GET: Interests
        GenericRepository<TBLINTERESTS> repo = new GenericRepository<TBLINTERESTS>();

		[HttpGet]
		public ActionResult Index()
        {
            var intrests = repo.List();
            return View(intrests);
        }
		[HttpPost]
		public ActionResult Index(TBLINTERESTS i)
		{
			var t = repo.Find(x => x.ID == 1);
			t.DESCRIPTION1 = i.DESCRIPTION1;
			t.DESCRIPTION2 = i.DESCRIPTION2;
			repo.Tupdate(t);
			return RedirectToAction("Index");
		}

	}
}