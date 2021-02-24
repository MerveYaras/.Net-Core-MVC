using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCore_PostgreSQL.Data.Entity;

namespace NetCore_PostgreSQL.Controllers
{
    public class UrunController : Controller
    {
        public IActionResult Index()
        {
            ETicaretDbContext tablo = new ETicaretDbContext();
            var uruns = tablo.Uruns.ToList();

            var urunvms = uruns.Select(x => new Urun()
            {
                Id = x.Id,
                Ad = x.Ad,
                Fiyat = x.Fiyat,
                ImageUrl = x.ImageUrl

            }).Skip(10).Take(5).ToList();
            return View(urunvms);
        }

        public ActionResult Delete()
        {
            int id = Convert.ToInt32(Request.Query["id"]);

            ETicaretDbContext tablo = new ETicaretDbContext();
            var urun = tablo.Uruns.FirstOrDefault(x => x.Id == id);
            tablo.Uruns.Remove(urun);
            tablo.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update()
        {
            int id = Convert.ToInt32(Request.Query["id"]);
            ETicaretDbContext tablo = new ETicaretDbContext();
            var urun = tablo.Uruns.FirstOrDefault(x => x.Id == id);

            Urun vm = new Urun()
            {
                Id = urun.Id,
                Ad = urun.Ad,
                Fiyat = urun.Fiyat,
                ImageUrl = urun.ImageUrl

            };

            return View(vm);
        }
        [HttpPost]
        public ActionResult Update(Urun c)
        { 
            ETicaretDbContext tablo = new ETicaretDbContext();
            var urun = tablo.Uruns.FirstOrDefault(x => x.Id == c.Id);
            urun.Id = c.Id;
            urun.Ad = c.Ad;
            urun.Fiyat = c.Fiyat;
            urun.ImageUrl = c.ImageUrl;
            tablo.SaveChanges();
            return View();
        }

        [HttpPost]
        public IActionResult UrunEkle(Urun c)
        {

            if (ModelState.IsValid)
            {

            }

            //veritabanına yazdır
            if (c.Id > 0)
            {
                //update
            }
            else
            {
                ETicaretDbContext tablo = new ETicaretDbContext();
                Urun c2 = new Urun();
                c2.Ad = c.Ad;
                c2.Fiyat = c.Fiyat;
                c2.ImageUrl = c.ImageUrl;
                tablo.Add(c2);
                tablo.SaveChanges();
            }

            return View();
        }
        [HttpGet]
        public IActionResult UrunEkle()
        {
            return View();
        }

        public IActionResult SepeteEkle()
        {
            string KullaniciEmail = HttpContext.Session.GetString("e-Mail");
            ETicaretDbContext tablo = new ETicaretDbContext();
            int kId = tablo.Kullanicis.FirstOrDefault(x => x.EMail == KullaniciEmail).Id;
            string urunid = HttpContext.Request.Query["id"];
            string urunfiyat = HttpContext.Request.Query["fiyat"];
            Sepet sepet = new Sepet();
            sepet.KullaniciId = kId;
            sepet.UrunAdet = 1;
            sepet.UrunId = Convert.ToInt32(urunid);
            tablo.Sepets.Add(sepet);
            tablo.SaveChanges();
            return Redirect("/Home/Index");
        }

        public IActionResult Sepetim()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            string ad = ViewBag.Username;
            ETicaretDbContext tablo = new ETicaretDbContext();
            int id = tablo.Kullanicis.FirstOrDefault(x => x.Ad == ad).Id;
            var userSepet = tablo.Sepets.Include(x => x.Urun).Include(x => x.Kullanici).Where(x => x.KullaniciId == id).ToList();
            ViewBag.liste1 = userSepet;
            return View();
        }

        public IActionResult AdetYukselt()
        {
            int urunid = Convert.ToInt32(HttpContext.Request.Query["id"]);

            ViewBag.Username = HttpContext.Session.GetString("username");
            string ad = ViewBag.Username;
            ETicaretDbContext tablo = new ETicaretDbContext();
            int id = tablo.Kullanicis.FirstOrDefault(x => x.Ad == ad).Id;
            var guncellenecekUrun = tablo.Sepets.Include(x => x.Urun).Include(x => x.Kullanici).Where(x => x.KullaniciId == id && x.UrunId == urunid).FirstOrDefault();
            guncellenecekUrun.UrunAdet++;
            tablo.SaveChanges();

            return Redirect("/Urun/Sepetim");
        }

        public IActionResult AdetAzalt()
        {
            int urunid = Convert.ToInt32(HttpContext.Request.Query["id"]);

            ViewBag.Username = HttpContext.Session.GetString("username");
            string ad = ViewBag.Username;
            ETicaretDbContext tablo = new ETicaretDbContext();
            int id = tablo.Kullanicis.FirstOrDefault(x => x.Ad == ad).Id;
            var guncellenecekUrun = tablo.Sepets.Include(x => x.Urun).Include(x => x.Kullanici).Where(x => x.KullaniciId == id && x.UrunId == urunid).FirstOrDefault();
            guncellenecekUrun.UrunAdet--;
            tablo.SaveChanges();

            return Redirect("/Urun/Sepetim");
        }

        public IActionResult AdresGir()
        {
            //adres sayfası açılır
            ETicaretDbContext tablo = new ETicaretDbContext();
            int K_id = Convert.ToInt32(HttpContext.Request.Query["id"]);
            var Adres = tablo.Adres.Where(x => x.KullaniciId == K_id).ToList();
            ViewBag.KListe = Adres;
            return View();
        }

        public ActionResult YeniAdresEkle(Adres k)
        {
            //yeni adres eklenir
            string email = HttpContext.Session.GetString("e-Mail");
            string kullaniciAd = HttpContext.Session.GetString("username");
            ETicaretDbContext tablo = new ETicaretDbContext();
            int id = tablo.Kullanicis.FirstOrDefault(x => x.EMail == email).Id;
            Adres a = new Adres();
            a.KullaniciId = id;
            a.KullaniciAd = kullaniciAd;
            a.YeniAdres = k.YeniAdres;
            a.Telefon = k.Telefon;
            a.EMail = k.EMail;
            a.AdresBaslik = k.AdresBaslik;
            tablo.Adres.Add(a);
            tablo.SaveChanges();
            return Redirect("/Urun/AdresGir?id="+id);
        }
        public ActionResult SiparisEkle( )
        {
            string email = HttpContext.Session.GetString("e-Mail");
            ETicaretDbContext tablo = new ETicaretDbContext();
            int id = tablo.Kullanicis.FirstOrDefault(x => x.EMail == email).Id;

            return View(); }
            

    }
}

