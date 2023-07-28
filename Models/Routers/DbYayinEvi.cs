using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    static class DbYayinEvi
    {
        public static List<EntityYayineviListe> ListeyeEkle()
        {
            var res = URL.Yayinevi.YayinEviListeyeEkle.Get<List<EntityYayineviListe>>(urlEk: $"");
            return res;
        }

        public static bool sil(EntityYayineviListe y)
        {
            int ID = y.ID;
            var res = URL.Yayinevi.YayineviSil.Get<Boolean>(urlEk: $"?ID={ID}");

            if (res == false)
            {
                return false;
            }
            return true;
        }
        public static bool EkleDuzenle(EntityFullYayinevi y)
        {
            if (y != null)
            {
                string strJson = JsonSerializer.Serialize(y);
                //Json verimizi stringContent'e çeviriyoruz 
                StringContent stringwrap = new StringContent(strJson);
                //Daha fazla veri vermek veya application şeklini değiştirmek istersek alttaki kodu da kullanabiliriz.
                //HttpContent httpContent = new StringContent(strJson, System.Text.Encoding.UTF8, "application/json");
                var res = URL.Yayinevi.YayineviEkleGuncelle.Post<bool>(Body: stringwrap);
                return res;

            }
            else
            {
                return false;
            }
        }

        public static bool YK(EntityFullYayinevi id)
        {
            var yayineviid = id.ID;
            var res = URL.Yayinevi.YayineviKontrol.Get<EntityFullYazar>(urlEk: $"?ID={yayineviid}");
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
