﻿using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

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
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());

        MessageValidator messagevalidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messageList = mm.GetListInbox(p);

            return View(messageList);
        }

        public ActionResult Sendbox(string p)
        {

            var messageList = mm.GetListSendBox(p);
            return View(messageList);
        }

        [HttpGet]
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }


        [HttpGet]
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }


        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {

            ValidationResult results = messagevalidator.Validate(p);

            if (results.IsValid)
            {
                p.MessageDate =DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }


            return View();
        }



    }
}