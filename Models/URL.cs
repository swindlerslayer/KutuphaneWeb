using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using static KutuphaneWeb.Models.Routers.Degiskenler;
using KutuphaneWeb.Models.Routers;

namespace KutuphaneWeb.Models
{
    public static class URL
    {
        public static class Kitap
        {
            public static string KitapSil
            {
                get
                {
                    return "api/kitapsil";
                }
            }
            public static string KitalGetirTekDetayli
            {
                get
                {
                    return "api/kitapgetir";
                }
            }
            public static string KitapGetirListeyeEkle
            {
                get
                {
                    return "api/kitaplisteyeekle";
                }
            }

            public static string KitapResimSil
            {
                get
                {
                    return "api/resimsil";
                }
            }
            public static string KitapEkleDuzenle
            {
                get
                {
                    return "api/ekleduzenle";
                }
            }

        }
        public static class Yazar
        {
            public static string YazarSil
            {
                get
                {
                    return "api/yazarsil";
                }
            }
            public static string YazarGetirTekDetaylı
            {
                get
                {
                    return "api/yazargetir";
                }
            }
            public static string YazarEkleDuzenle
            {
                get
                {
                    return "api/yazarekleduzenle";
                }
            }
            public static string YazarTümYazarlarıListele
            {
                get
                {
                    return "api/yazarlisteyeekle";
                }
            }
            public static string YazarKontrol
            {
                get
                {
                    return "api/yazarkontrol";
                }
            }
        }
        public static class Yayinevi
        {

            public static string YayinEviListeyeEkle
            {
                get
                {
                    return "api/yayinevilisteyeekle";
                }
            }

            public static string YayineviGetirTekDetaylı
            {
                get
                {
                    return "api/yayinevigetir";
                }
            }
            public static string YayineviSil
            {
                get
                {
                    return "api/yayinevisil";
                }
            }
            public static string YayineviEkleGuncelle
            {
                get
                {
                    return "api/yayineviekleduzenle";
                }
            }
            public static string YayineviKontrol
            {
                get
                {
                    return "api/yayinevikontrol";
                }
            }

        }
        public static class KitapTuru
        {
            public static string KitapTurGetirTekDeyayli
            {
                get
                {
                    return "api/kitapturugetir";
                }
            }
            public static string KitapTurSil
            {
                get
                {
                    return "api/kitapturusil";
                }
            }
            public static string KitapTurEkleDuzenle
            {
                get
                {
                    return "api/kitapturuekleduzenle";
                }
            }

            public static string KitapTurKontrol
            {
                get
                {
                    return "api/kitapturkontrol";
                }
            }

            public static string KitapTurListeyeEkle
            {
                get
                {
                    return "api/kitapturulisteyeekle";
                }
            }


        }
        public static class Ogrenci
        {
            public static string OgrenciSil
            {
                get
                {
                    return "api/ogrencisil";
                }
            }
            public static string OgrenciGetirTekDetayli
            {
                get
                {
                    return "api/ogrencigetir";
                }
            }

            public static string OgrenciListeyeEkle
            {
                get
                {
                    return "api/ogrencilisteyeekle";
                }
            }
            public static string OgrenciKontrol
            {
                get
                {
                    return "api/ogrencikontrol";
                }
            }

            public static string OgrenciEkleDuzenle
            {
                get
                {
                    return "api/ogrenciekleduzenle";
                }
            }
        }
        public static class OgrenciKitap
        {


            public static string OgrenciKitapKitapListesiGetir
            {
                get
                {
                    return "api/okitaplisteyeekle";
                }
            }
            public static string OgrenciKitapTekGetirDetayli
            {
                get
                {
                    return "api/ogrencikitapteklisteyeekle";
                }
            }
            public static string OgrenciKitapEkleDuzenle
            {
                get
                {
                    return "api/kitapogrenciekleduzenle";
                }
            }

            public static string OgrenciKitapSil
            {
                get
                {
                    return "api/kitapogrencisil";
                }
            }


            public static string OgrenciKitapListeyeEkle
            {
                get
                {

                    return "api/ogrkitaplisteyeekle";
                }
            }
        }
        public static class Kullanici
        {
            public static string KullaniciKontrol { get { return "api/kullanici/kullaniciKontrol"; } }
        }
    }
    public static class Extension
    {
        private static string uri = "https://localhost:44399/";
        private static TokenClass TokenAl(string kullaniciAdi = "", string Password = "", bool LoginMi = false)
        {
            using (HttpClient client = new HttpClient())
            {
                var values = new Dictionary<string, string>();
                values.Add("grant_type", "password");
                values.Add("username", LoginMi ? kullaniciAdi : StaticDegiskenler.kullanici.KullaniciAdi);
                values.Add("password", LoginMi ? Password : StaticDegiskenler.kullanici.Parola);

                var content = new FormUrlEncodedContent(values);

                var url = new Uri(uri + "token");
                var res = client.PostAsync(url, content).Result;
                var cont = res.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<TokenClass>(cont);
                return data;
            }
        }


        public static T Get<T>(this string u, string urlEk = "")
        {

            using (HttpClient client = new HttpClient())
            {

                var token = TokenAl();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);
                var url = new Uri(uri + u + urlEk);
                var res = client.GetAsync(url).Result;
                var content = res.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<T>(content);
                return data;




            }
        }

        public static T Post<T>(this string u, HttpContent Body)
        {
            using (HttpClient client = new HttpClient())
            {
                var token = TokenAl();
                client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token.access_token);
                var url = new Uri(uri + u);//+ urlEk
                var res = client.PostAsync(url, Body).Result;
                var content = res.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<T>(content);
                return data;
            }
        }
        public static T Get<T>(this string u, string urlEk = "", string kullaniciAdi = "", string parola = "")
        {

            using (HttpClient client = new HttpClient())
            {
                var token = TokenAl(kullaniciAdi: kullaniciAdi, Password: parola, LoginMi: true);
                var url = new Uri(uri + u + urlEk);
                client.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", token.access_token);
                var res = client.GetAsync(url).Result;
                var content = res.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<T>(content);
                return data;
            }
        }
        public static T Post<T>(this string u, HttpContent Body, string urlEk = "", string kullaniciAdi = "", string Password = "")
        {

            using (HttpClient client = new HttpClient())
            {
                var token = TokenAl(kullaniciAdi: kullaniciAdi, Password: Password, LoginMi: true);
                var url = new Uri(uri + u + urlEk);
                client.DefaultRequestHeaders.Authorization =
               new AuthenticationHeaderValue("Bearer", token.access_token);
                var res = client.PostAsync(url, Body).Result;
                var content = res.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<T>(content);
                return data;
            }
        }
    }
}