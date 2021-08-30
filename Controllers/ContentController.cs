using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        ContentManager _contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeding(int id)
        {
            var contents =_contentManager.GetListById(id);
            return View(contents);
        }
    }
}