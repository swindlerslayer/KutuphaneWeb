﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneWeb.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        public ActionResult KitapView()
        {
            return View();
        }
    }
}