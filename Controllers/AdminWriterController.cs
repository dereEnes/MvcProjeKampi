using Business.Abstract;
using Business.Concrete;
using Business.Validation.FluentValidation;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
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
        WriterValidator writerValidator = new WriterValidator();
        public ActionResult Index()
        {
            var writers = writerService.GetAll();
            return View(writers);
        }
        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            
            ValidationResult validationResult = writerValidator.Validate(writer);
            if (validationResult.IsValid)
            {
                writerService.Insert(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerToUpdate = writerService.GetById(id);
            return View(writerToUpdate);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult validationResult = writerValidator.Validate(writer);
            if (validationResult.IsValid)
            {
                writerService.Update(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            
            return RedirectToAction("Index");
        }
    }
}