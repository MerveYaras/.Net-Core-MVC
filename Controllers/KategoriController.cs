using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore_PostgreSQL.Data.Entity;

namespace NetCore_PostgreSQL.Controllers
{
    public class KategoriController : Controller
    {
        public IActionResult Index()
        {
            ETicaretDbContext tablo = new ETicaretDbContext();
            var categories = tablo.Categories.ToList();

            var categoryVMs = categories.Select(x => new Category()
            {
                Id = x.Id,
                Ad = x.Ad
            }).ToList();
            return View(categoryVMs);
        }

        public ActionResult Delete()
        {
            int id = Convert.ToInt32(Request.Query["id"]);

            ETicaretDbContext tablo = new ETicaretDbContext();
            var category = tablo.Categories.FirstOrDefault(x => x.Id == id);
            tablo.Categories.Remove(category);
            tablo.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update()
        {
            int id = Convert.ToInt32(Request.Query["id"]);
            ETicaretDbContext tablo = new ETicaretDbContext();
            var category = tablo.Categories.FirstOrDefault(x => x.Id == id);

            Category vm = new Category()
            {
                Id = category.Id,
                Ad = category.Ad
            };

            return View(vm);
        }
        [HttpPost]
        public ActionResult Update(Category c)
        {

            ETicaretDbContext tablo = new ETicaretDbContext();
            var category = tablo.Categories.FirstOrDefault(x => x.Id == c.Id);
            category.Ad = c.Ad;
            tablo.SaveChanges();
            return View();
        }

        [HttpPost]
        public IActionResult KategoryEkle(Category c)
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
                Category c2 = new Category();
                c2.Ad = c.Ad;
                tablo.Add(c2);
                tablo.SaveChanges();
            }

            return View();
        }
        [HttpGet]
        public IActionResult KategoryEkle()
        {
            return View();
        }
    }
}
