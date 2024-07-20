using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCV.Models.Entity;
using MVCCV.Repositories;

namespace MVCCV.Controllers
{
    public class ContactController : Controller
    {
		// GET: Contact
		
		GenericRepository<TBLCONTACT> repo = new GenericRepository<TBLCONTACT>();
		public ActionResult Index()
        {
            var message = repo.List();
            return View(message);
        }
    }
}