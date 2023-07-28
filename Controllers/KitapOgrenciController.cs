using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneWeb.Controllers
{
    public class KitapOgrenciController : Controller
    {
        // GET: KitapOgrenci
        public ActionResult KitapOgrenciView()
        {
            return View();
        }
    }
}