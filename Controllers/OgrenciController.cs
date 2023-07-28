using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneWeb.Controllers
{
    public class OgrenciController : Controller
    {
        // GET: Öğrenci
        public ActionResult OgrenciView()
        {
            return View();
        }
    }
}