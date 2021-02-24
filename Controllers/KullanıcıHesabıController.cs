using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCore_PostgreSQL.Data.Entity;
using NetCore_PostgreSQL.Models;

namespace NetCore_PostgreSQL.Controllers
{
    public class KullanıcıHesabıController : Controller
    {
        public object Session { get; private set; }
       
        [HttpGet]
        public IActionResult Index()
        {
            Kullanici k = new Kullanici();
            if ( Request.Cookies["username"] != null)
            {
            k.EMail =  Request.Cookies["username"];
            k.Sifre =  Request.Cookies["password"]; 
            }

            return View(k);
        }
        [HttpPost]
        public IActionResult Index(Kullanici model)
        {
            ETicaretDbContext tablo = new ETicaretDbContext();
            Kullanici k = tablo.Kullanicis.FirstOrDefault(x => x.EMail == model.EMail);
            //Login kontrol işlemleri ve yönlendirmeler
            if (k != null)
            {
                HttpContext.Session.SetString("username", k.Ad);
                HttpContext.Session.SetString("e-Mail", k.EMail);
                k.RememberMe = model.RememberMe;
                tablo.SaveChanges();
                if (k.RememberMe)
                {
                    CookieOptions option = new CookieOptions();
                    Response.Cookies.Append("username", k.EMail, option);
                    Response.Cookies.Append("password", k.Sifre, option);
                }
                return Redirect("~/Home/Index");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz bilgiler, tekrar deneyiniz";
            }
            return View();
        }
        [HttpPost]
        public IActionResult UyeOl(Kullanici c)
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
                Kullanici c2 = new Kullanici();
                c2.Ad = c.Ad;
                c2.Adres = c.Adres;
                c2.EMail = c.EMail;
                c2.Sifre = c.Sifre;
                c2.RememberMe = false;
                c2.Telefon = c.Telefon;
                tablo.Add(c2);
                tablo.SaveChanges();
            }

            return View();
        }
        [HttpGet]
        public IActionResult UyeOl()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       

    }
}
