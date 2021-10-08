using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        private HeadingManager _headingManager = new HeadingManager(new EfHeadingDal());
        private CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        private WriterManager _writerManager = new WriterManager(new EfWriterDal());
        private ContentManager _contentManager = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            var result = _headingManager.GetAll();
            ViewData["name"] = "Enes";
            return View(result);
        }
        [HttpPost]
        public ActionResult Insert(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _headingManager.Insert(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Insert()
        {
            List<SelectListItem> catetories = (from x in _categoryManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value= x.CategoryId.ToString()
                                               }).ToList();
            List<SelectListItem> writers = (from x in _writerManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.WriterName+" "+x.WriterSurName,
                                                   Value = x.WriterId.ToString()
                                               }).ToList();
            ViewBag.valueCategories = catetories;
            ViewBag.valueWriters = writers;
            return View();
        }
        public ActionResult Delete(int id)
        {
            _headingManager.Delete(_headingManager.GetById(id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Heading heading)
        {

            heading.HeadingStatus = false;
            _headingManager.Update(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> catetories = (from x in _categoryManager.GetAll()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            ViewBag.valueCategories = catetories;
      
            Heading heading = _headingManager.GetById(id);
            return View(heading);
        }
        public ActionResult DeleteHeading(int id) 
        {
            var heading = _headingManager.GetById(id);
            heading.HeadingStatus = false;
            _headingManager.Update(heading);
            return RedirectToAction("Index");
        }
        public ActionResult Active(int id)
        {
            var heading = _headingManager.GetById(id);
            heading.HeadingStatus = true;
            _headingManager.Update(heading);
            return RedirectToAction("Index");
        }
        
        
        

    }
}