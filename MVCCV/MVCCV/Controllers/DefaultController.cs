using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;

namespace MVCCV.Controllers
{
	[AllowAnonymous]
    public class DefaultController : Controller
    {
		// GET: Default
		CVEntities db = new CVEntities();
		public ActionResult Index()
        {
            var values = db.TBLABOUT.ToList();
            return View(values);
        }

		public PartialViewResult SocialMedia()
		{
			var sm = db.TBLSOCIALMEDIA.Where(x=>x.STATUS == true).ToList();
			return PartialView(sm);
		}
		public PartialViewResult Experience()
        {
            var experience = db.TBLEXPERIENCE.ToList();
            return PartialView(experience);
        }
		public PartialViewResult Educations()
		{
			var educations = db.TBLEDUCATION.ToList();
			return PartialView(educations);
		}

		public PartialViewResult Skills()
		{
			var skill = db.TBLSKILLS.ToList();
			return PartialView(skill);
		}

		public PartialViewResult Interests()
		{
			var interests = db.TBLINTERESTS.ToList();
			return PartialView(interests);
		}
		
		public PartialViewResult Certificates()
		{
			var certificates = db.TBLCERTIFICATES.ToList();
			return PartialView(certificates);
		}
		[HttpGet]
		public PartialViewResult Contact()
		{
			return PartialView();
		}
		[HttpPost]
		public PartialViewResult Contact(TBLCONTACT c)
		{
			c.DATE = DateTime.Now.ToShortDateString();
			db.TBLCONTACT.Add(c);
			db.SaveChanges();
			return PartialView();
		}
	}
}