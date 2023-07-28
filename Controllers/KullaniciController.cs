using KutuphaneWeb.Models.Routers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static KutuphaneWeb.Models.Routers.Degiskenler;

namespace KutuphaneWeb.Controllers
{
    public class KullaniciController : Controller
    {
        string hash = "slkjgdngı0243582ej";
        public string Encrypt(string sifre)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(sifre);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            
            try
            {
                // var ss = Encrypt(password);
                var res = DbKullanici.KullaniciControl(username, password, true);
                StaticDegiskenler.kullanici = res;
                if (res.ID != null)
                {
                    return RedirectToAction("Index", "Anasayfa");
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Giriş başarısız!";
                return View();
            }

   
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Kayit(string username, string password)
        {
            EntityKullanici kullanici = new EntityKullanici();
            kullanici.KullaniciAdi = username;
            kullanici.Parola = password;
            bool kontrol = DbKullanici.KK(kullanici);
            if (kontrol != true)
            {
                bool kaydedildi = DbKullanici.EkleDuzenle(kullanici);
                if (kaydedildi)
                {
                    return RedirectToAction("Index", "Anasayfa");
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        // Diğer Action metodları ve işlemler
    }
}