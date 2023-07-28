
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
    public class DbOgrenci
    {
        public static EntityFullOgrenci OgrenciGetir(int id)
        {
            var res = URL.Ogrenci.OgrenciGetirTekDetayli.Get<EntityFullOgrenci>(urlEk: $"?ID={id}");
            return res;
        }
        public static bool EkleDuzenle(EntityFullOgrenci y)
        {
            if (y != null)
            {
                string strJson = JsonSerializer.Serialize(y);
                //Json verimizi stringContent'e çeviriyoruz 
                StringContent stringwrap = new StringContent(strJson);
                //Daha fazla veri vermek veya application şeklini değiştirmek istersek alttaki kodu da kullanabiliriz.
                //HttpContent httpContent = new StringContent(strJson, System.Text.Encoding.UTF8, "application/json");
                var res = URL.Ogrenci.OgrenciEkleDuzenle.Post<Boolean>(Body: stringwrap);
                if (res = true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        public static bool sil(EntityOgrenciListe id)
        {
            int ID = id.ID;
            var res = URL.Ogrenci.OgrenciSil.Get<Boolean>(urlEk: $"?ID={ID}");
            if (res == false)
            {
                return false;
            }

            return true;


        }
        public static bool OK(EntityFullOgrenci id)
        {
            var yazarid = id.ID;
            var res = URL.Ogrenci.OgrenciKontrol.Get<EntityFullOgrenci>(urlEk: $"?ID={yazarid}");
            if (res.ID == 0)
            {
                return false;

            }
            else
            {
                return true;
            }

        }
        public static List<EntityOgrenciListe> ListeyeEkle()
        {

            var res = URL.Ogrenci.OgrenciListeyeEkle.Get<List<EntityOgrenciListe>>(urlEk: $"");
            return res;

        }
        public List<EntityOgrenciListe> GetOgrenciListesi()
        {
            var res = URL.Ogrenci.OgrenciListeyeEkle.Get<List<EntityOgrenciListe>>(urlEk: $"");
            return res;

        }
    }

    public class OgrenciViewModel
    {
        public int ID { get; set; }
        public string AdiSoyadi { get; set; }
        public int? OkulNo { get; set; }
    }
}
