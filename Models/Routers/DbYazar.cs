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
    static class DbYazar
    {

        public static bool EkleDuzenle(EntityFullYazar y)
        {
            if (y != null)
            {
                string strJson = JsonSerializer.Serialize(y);
                //Json verimizi stringContent'e çeviriyoruz 
                StringContent stringwrap = new StringContent(strJson);
                //Daha fazla veri vermek veya application şeklini değiştirmek istersek alttaki kodu da kullanabiliriz.
                //HttpContent httpContent = new StringContent(strJson, System.Text.Encoding.UTF8, "application/json");
                var res = URL.Yazar.YazarEkleDuzenle.Post<bool>(Body: stringwrap);
                return res;
            }
            else
            {
                return false;
            }

        }
        public static List<EntityYazarListe> ListeyeEkle()
        {

            var res = URL.Yazar.YazarTümYazarlarıListele.Get<List<EntityYazarListe>>(urlEk: $"");
            return res;

        }

        public static bool sil(EntityYazarListe id)
        {
            int ID = id.ID;
            var res = URL.Yazar.YazarSil.Get<bool>(urlEk: $"?ID={ID}");
            if (res == false)
            {
                return false;
            }

            return true;


        }

        public static bool YK(EntityFullYazar id)
        {
            var yazarid = id.ID;
            var res = URL.Yazar.YazarKontrol.Get<EntityFullYazar>(urlEk: $"?ID={yazarid}");
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
