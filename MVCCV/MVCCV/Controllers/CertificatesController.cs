using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;

namespace MVCCV.Controllers
{
	
	public class CertificatesController : Controller
    {
		
		// GET: Certificates
		GenericRepository<TBLCERTIFICATES> repo = new GenericRepository<TBLCERTIFICATES>();
		public ActionResult Index()
        {
            var values =repo.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult BringCertificates(int id)
        {
            var certi =repo.Find(x => x.ID == id);
            return View(certi);
        }
		[HttpPost]
		public ActionResult BringCertificates(TBLCERTIFICATES c)
		{
			var certi = repo.Find(x => x.ID == c.ID);
            certi.DESCRIPTION = c.DESCRIPTION;
            certi.LINK = c.LINK;
            certi.DATE = c.DATE;
            repo.Tupdate(certi);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public ActionResult AddCertificates()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddCertificates(TBLCERTIFICATES cr)
		{
			repo.Tadd(cr);
			return RedirectToAction("Index");
		}

		public ActionResult DeleteCertificates(int id)
		{
			var certificates = repo.Find(x => x.ID == id);
			repo.Tdelete(certificates);
			return RedirectToAction("Index");
		}
	}
}