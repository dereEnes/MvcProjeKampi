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
    public class MessageController : Controller
    {
        MessageManager _messageManager = new MessageManager(new EfMessageDal());
        MessageValidator _messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var messageList = _messageManager.GetListOfInbox();
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            var messageList = _messageManager.GetListOfSendbox();
            return View(messageList);
        }

        public ActionResult InboxMessageDetails(int id)
        {
            var value = _messageManager.GetById(id);
            return View(value);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var value = _messageManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult validationResult = _messageValidator.Validate(message);
            if (validationResult.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _messageManager.Insert(message);
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
        public ActionResult NewMessage()
        {
            return View();
        }
    }
}