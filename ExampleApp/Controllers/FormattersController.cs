﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ExampleApp.Controllers
{
    public class FormattersController : Controller
    {
        // GET: Formatters
        public ActionResult Index()
        {
            return View(GlobalConfiguration.Configuration.Formatters);
        }
    }
}