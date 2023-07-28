using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using static KutuphaneWeb.Models.Routers.Degiskenler;
using System.Text.Json;

namespace KutuphaneWeb.Models.Routers
{
    static class DbKitap
    {
        public static object ListeyeEkle()
        {
            var res = URL.Kitap.KitapGetirListeyeEkle.Get<List<EntityKitap>>(urlEk: $"");
            return res;
        }

        public static bool EkleDuzenle(EntityFullKitap k)
        {
            if (k != null)
            {
                string strJson = JsonSerializer.Serialize(k);
                //Json verimizi stringContent'e çeviriyoruz 
                StringContent stringwrap = new StringContent(strJson);
                //Daha fazla veri vermek veya application şeklini değiştirmek istersek alttaki kodu da kullanabiliriz.
                //HttpContent httpContent = new StringContent(strJson, System.Text.Encoding.UTF8, "application/json");
                var res = URL.Kitap.KitapEkleDuzenle.Post<EntityFullKitap>(Body: stringwrap);
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static bool KitapKontrolKontrol(Kitap kntrl)
        //{
        //    using (KutuphaneEntities2 db = new KutuphaneEntities2())
        //    {

        //        var kitap = db.Kitap.FirstOrDefault(x => x.Adi == kntrl.Adi);
        //        if (kitap != null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        public static bool Resimsil(int id)
        {

            var res = URL.Kitap.KitapResimSil.Get<EntityFullKitap>(urlEk: $"?ID={id}");
            return true;

        }

        public static bool sil(int id)
        {
            var res = URL.Kitap.KitapSil.Get<bool>(urlEk: $"?ID={id}");
            return res;

        }

        public static EntityFullKitap KitapGetir(int id)
        {
            var res = URL.Kitap.KitalGetirTekDetayli.Get<EntityFullKitap>(urlEk: $"?ID={id}");
            return res;
        }
    }
}
