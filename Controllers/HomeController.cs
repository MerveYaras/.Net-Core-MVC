using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore_PostgreSQL.Data.Entity;
using NetCore_PostgreSQL.Models;

namespace NetCore_PostgreSQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            ETicaretDbContext tablo = new ETicaretDbContext();
            ViewBag.liste1 = tablo.Categories.Select(x => x.Ad).ToList();
            ViewBag.liste2 = tablo.Uruns.ToList();
            return View();
        }
         
       
        public IActionResult VeriEkle()
        {
            ETicaretDbContext tablo = new ETicaretDbContext();
            Category c = new Category();
            c.Ad = "Telefon";
            Category c2 = new Category();
            c2.Ad = "Bilgisayar";

            tablo.Add(c);
            tablo.Add(c2);
            tablo.SaveChanges();

            for (int i = 0; i < 10; i++)
            {
                Urun u = new Urun();
                u.Ad = "İphone " + i;
                u.KategoriId = c.Id;
                u.Fiyat = 1000 * (i + 1);
                u.ImageUrl = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-12-black-select-2020?wid=940&hei=1112&fmt=png-alpha&qlt=80&.v=1604343702000";
                tablo.Uruns.Add(u);
            }

            for (int i = 0; i < 10; i++)
            {
                Urun u = new Urun();
                u.Ad = "Macbook " + i;
                u.KategoriId = c2.Id;
                u.Fiyat = 2000 * (i + 1);
                u.ImageUrl = "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/mbp-spacegray-select-202011?wid=452&hei=420&fmt=jpeg&qlt=95&op_usm=0.5,0.5&.v=1603406905000";

                tablo.Uruns.Add(u);
            }
            tablo.SaveChanges();


            return View();
        }
        public IActionResult Privacy()
        {
            HttpContext.Session.GetString("username");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult UrunEkle()
        {
            return View();
        }
    }
}
