using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Collections.Generic;
using System.Linq;
using System;
using static KutuphaneWeb.Models.Routers.Degiskenler;
using System.Text.Json;
using System.Net.Http;

namespace KutuphaneWeb.Models.Routers
{
    public class OgrenciKitap
    {
        public static EntityFullKitapOgrenci kitapogrencigetir(int id)
        {
            var res = URL.OgrenciKitap.OgrenciKitapTekGetirDetayli.Get<EntityFullKitapOgrenci>(urlEk: $"?ID={id}");
            return res;
        }
        public static bool sil(EntityFullKitapOgrenci y)
        {
            int ID = y.ID;
            var res = URL.OgrenciKitap.OgrenciKitapSil.Get<bool>(urlEk: $"?ID={ID}");
            return res;
        }
        public static bool EkleDuzenle(EntityFullKitapOgrenci k)
        {
            if (k != null)
            {
                string strJson = JsonSerializer.Serialize(k);
                //Json verimizi stringContent'e çeviriyoruz 
                StringContent stringwrap = new StringContent(strJson);
                //Daha fazla veri vermek veya application şeklini değiştirmek istersek alttaki kodu da kullanabiliriz.
                //HttpContent httpContent = new StringContent(strJson, System.Text.Encoding.UTF8, "application/json");
                var res = URL.OgrenciKitap.OgrenciKitapEkleDuzenle.Post<bool>(Body: stringwrap);
                return res;
            }
            else
            {
                return false;
            }
        }



        public List<KitapViewModel> GetKitapListesi()
        {
            //yanlıs veriler dönüyor 
            var res = URL.OgrenciKitap.OgrenciKitapKitapListesiGetir.Get<List<KitapViewModel>>(urlEk: $"");
            return res;
        }
    }
    public class OKgrid
    {

        public List<OKViewModel> GetGridDoldur()
        {
            var res = URL.OgrenciKitap.OgrenciKitapListeyeEkle.Get<List<OKViewModel>>(urlEk: $"");
            return res;
        }
    }
    public class KitapViewModel
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public string YayinEviAdi { get; set; }
    }


    public class OKViewModel
    {
        public int? ID { get; set; }

        public string AdiSoyadi { get; set; }
        public int? OkulNo { get; set; }
        public string Adi { get; set; }
        public string YayinEviAdi { get; set; }
        public DateTime? AlisTarihi { get; set; }
        public Nullable<DateTime> TeslimTarihi { get; set; }
        public bool TeslimDurumu { get; set; }

    }

}
