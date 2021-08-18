using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminWriterController : Controller
    {
        IWriterService writerService = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var writers = writerService.GetAll();
            return View(writers);
        }
    }
}