

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using static KutuphaneWeb.Models.Routers.Degiskenler;

namespace KutuphaneWeb.Models.Routers
{
    public static class DbKullanici
    {



        public static bool EkleDuzenle(EntityKullanici y)
        {
            if (y != null)
            {
                string strJson = JsonSerializer.Serialize(y);
                //Json verimizi stringContent'e çeviriyoruz 
                StringContent stringwrap = new StringContent(strJson);
                //Daha fazla veri vermek veya application şeklini değiştirmek istersek alttaki kodu da kullanabiliriz.
                //HttpContent httpContent = new StringContent(strJson, System.Text.Encoding.UTF8, "application/json");
                var res = URL.KitapTuru.KitapTurEkleDuzenle.Post<Boolean>(Body: stringwrap);
                return true;

            }
            else
            {
                return false;
            }

        }

        public static bool KK(EntityKullanici kntrl)
        {
            string kullaniciadi, kullaniciparola;
            kullaniciadi = kntrl.KullaniciAdi;
            kullaniciparola = kntrl.Parola;
            var data = URL.Kullanici.KullaniciKontrol.Get<bool>($"?kullaniciAdi={kullaniciadi}&parola={kullaniciparola}");
            return data;
        }
        public static EntityKullanici KullaniciControl(string kullaniciAdi, string parola, bool loginMi)
        {
            var data = URL.Kullanici.KullaniciKontrol.Get<EntityKullanici>($"?kullaniciAdi={kullaniciAdi}&parola={parola}", kullaniciAdi: kullaniciAdi, parola: parola);
            return data;
        }
    }
}
