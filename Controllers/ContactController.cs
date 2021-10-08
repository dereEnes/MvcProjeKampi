using Business.Concrete;
using Business.Validation.FluentValidation;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager _contactManager = new ContactManager(new EfContactDal());
        ContactValidator validationRules = new ContactValidator();


        public ActionResult Index()
        {
            var contactValues = _contactManager.GetAll();
            return View(contactValues);
        }
        public ActionResult ContactDetails(int id)
        {
            var contactValue = _contactManager.GetById(id);
            return View(contactValue);
        }
        public PartialViewResult MenuPartial()
        {

            return PartialView();
        }
    }
}