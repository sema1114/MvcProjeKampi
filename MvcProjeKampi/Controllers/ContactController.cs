﻿using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {


        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
            // GET: Contact
        public ActionResult Index()
        {
          var contactValues= cm.GetList();
            return View(contactValues);
        }


        [HttpGet]
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetByID(id);
            return View(contactValues);
        }

        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
    }
}