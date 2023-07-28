using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using KutuphaneWeb.Models;
using static KutuphaneWeb.Models.Routers.Degiskenler;



namespace KutuphaneWeb.Models.Routers
{
    static class DbKitapTuru
    {
        public static bool EkleDuzenle(EntityFullKitapTuru y)
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
        public static List<EntityKitapTuruListe> ListeyeEkle()
        {
            var res = URL.KitapTuru.KitapTurListeyeEkle.Get<List<EntityKitapTuruListe>>(urlEk: $"");
            return res;
        }
        public static bool sil(EntityKitapTuruListe y)
        {
            int ID = y.ID;
            var res = URL.KitapTuru.KitapTurSil.Get<Boolean>(urlEk: $"?ID={ID}");

            if (res == false)
            {
                return false;
            }
            return true;
        }

        public static bool KTKontrol(EntityFullKitapTuru id)
        {
            var kitapturu = id.ID;
            var res = URL.KitapTuru.KitapTurKontrol.Get<EntityFullKitapTuru>(urlEk: $"?ID={kitapturu}");
            if (res.ID == 0)
            {
                return false;

            }
            else
            {
                return true;
            }
        }

    }
}
