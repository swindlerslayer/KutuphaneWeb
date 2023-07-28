
using System;
using static KutuphaneWeb.Models.Routers.Degiskenler;

namespace KutuphaneWeb.Models.Routers
{
    public static class StaticDegiskenler
    {
        public static EntityKullanici kullanici { get; set; }
    }
    public class Degiskenler
    {
        public class EntityFullKitap
        {
            public int ID { get; set; }
            public string Adi { get; set; }
            public int? SayfaSayisi { get; set; }
            public int? KitapTurID { get; set; }
            public int? YayinEviID { get; set; }
            public int? YazarID { get; set; }
            public int? Barkod { get; set; }
            public string KayitYapan { get; set; }
            public DateTime? KayitTarihi { get; set; }
            public string DegisiklikYapan { get; set; }
            public DateTime? DegisiklikTarihi { get; set; }
            public byte[] Resim { get; set; }
        }
        public class EntityFullYayinevi
        {
            public int ID { get; set; }
            public string Adi { get; set; }
            public string KayitYapan { get; set; }
            public DateTime? KayitTarihi { get; set; }
            public int DegisiklikYapan { get; set; }
            public DateTime? DegisiklikTarihi { get; set; }
        }
        public class EntityFullYazar
        {
            public int ID { get; set; }
            public string AdiSoyadi { get; set; }
            public string KayitYapan { get; set; }
            public DateTime? KayitTarihi { get; set; }
            public string DegisiklikYapan { get; set; }
            public DateTime? DegisiklikTarihi { get; set; }
        }
        public class EntityFullKitapTuru
        {
            public int ID { get; set; }
            public string Adi { get; set; }
            public string KayitYapan { get; set; }
            public DateTime? KayitTarihi { get; set; }
            public string DegisiklikYapan { get; set; }
            public DateTime? DegisiklikTarihi { get; set; }

        }
        public class EntityFullOgrenci
        {
            public int ID { get; set; }
            public string AdiSoyadi { get; set; }
            public string KayitYapan { get; set; }
            public DateTime? KayitTarihi { get; set; }
            public string DegisiklikYapan { get; set; }
            public DateTime? DegisiklikTarihi { get; set; }
            public string Sinif { get; set; }
            public int OkulNo { get; set; }
            public string Bölüm { get; set; }
        }
        public class EntityFullKitapOgrenci
        {
            public int ID { get; set; }
            public int OgrenciID { get; set; }
            public int KitapID { get; set; }
            public DateTime AlisTarihi { get; set; }
            public DateTime? TeslimTarihi { get; set; }
            public int KullanıcıID { get; set; }
            public DateTime KayitTarihi { get; set; }
            public string DegisiklikYapan { get; set; }
            public DateTime? DegisiklikTarihi { get; set; }
            public bool TeslimDurumu { get; set; }
        }
        public class EntityKullanici
        {
            public int ID { get; set; }
            public string KullaniciAdi { get; set; }
            public string Parola { get; set; }
            public string KayitYapan { get; set; }
            public DateTime? KayitTarihi { get; set; }
            public string DegisiklikYapan { get; set; }
            public DateTime? DegisiklikTarihi { get; set; }
        }


        //Özel Entityler
        public class EntityKitap
        {
            public int ID { get; set; }
            public string Adi { get; set; }
            public int YazarID { get; set; }
            public string YazarAdi { get; set; }
            public byte[] Resim { get; set; }
        }
        public class TokenClass
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
        }
        public class EntityYazar
        {
            public int ID { get; set; }
            public string Adi { get; set; }
            public string YazarAdi { get; set; }
            public int? YazarID { get; set; }
        }
        public class EntityYazarListe
        {
            public int ID { get; set; }
            public string AdiSoyadi { get; set; }
        }
        public class EntityYayineviListe
        {
            public int ID { get; set; }
            public string Adi { get; set; }
        }
        public class EntityKitapTuruListe
        {
            public int ID { get; set; }
            public string Adi { get; set; }
        }
        public class EntityOkGridListe
        {
            public int ID { get; set; }
            public string Adi { get; set; }
            public string AdiSoyadi { get; set; }
            public int OkulNo { get; set; }
            public string YayinEviAdi { get; set; }
            public DateTime? AlisTarihi { get; set; }
            public DateTime? TeslimTarihi { get; set; }
            public bool TeslimDurumu { get; set; }

        }
        public class EntityOgrenciListe
        {
            public int ID { get; set; }
            public string AdiSoyadi { get; set; }
            public int? OkulNo { get; set; }
        }
    }

}
