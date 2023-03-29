//using Microsoft.AspNeBransore.Mvc;
using System.Collections.Generic;
using WebApplication2MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApplication2MVC.Controllers
{
    public class OgretmenController : Controller
    {
        public IActionResult Index()
        {
            List<Ogretmen> lst;
            using (var ctx = new OkulDbContext())
            {
                if (ctx is not null)
                {
                    lst = ctx.Ogretmenler.ToList();
                    return View(lst);
                }
                else return View();
            }

        }
        [HttpGet]
        public ActionResult OgretmenEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult OgretmenEkle(Ogretmen ogr)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Ogretmenler.Add(ogr);
                var sonuc = ctx.SaveChanges();
                if (sonuc > 0) TempData["Sonuc"] = true;
                else TempData["Sonuc"] = false;
            }
            //return View();
            return RedirectToAction("Index");
        }
        public IActionResult OgretmenSil(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogr = ctx.Ogretmenler.Find(id);
                ctx.Remove(ogr);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult OgretmenGuncelle(int id)
        {
            Ogretmen ogr;
            using (var ctx = new OkulDbContext())
            {
                ogr = ctx.Ogretmenler.Find(id);

            }
            return View(ogr);
        }
        [HttpPost]
        public IActionResult OgretmenGuncelle(Ogretmen ogr)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Entry(ogr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        public ViewResult OgretmenBilgi(int id)
        {
            //List<Ogretmen> Ogretmenler = new List<Ogretmen>(
            //    new Ogretmen() { id=1, AdSoyad="Ali AK", Brans="qwert123"},
            //    );
            var std1 = new Ogretmen();
            std1.Ogretmenid = 1;
            std1.AdSoyad = "Ali Aka";
            std1.Brans = "123234123";

            var std2 = new Ogretmen();
            std2.Ogretmenid = 2;
            std2.AdSoyad = "Veli Güllü";
            std2.Brans = "32659854";

            if (id == 1) ViewData["Ogretmen"] = std1;
            if (id == 2) ViewData["Ogretmen"] = std2;
            if (id == 3) ViewData["Ogretmen"] = null;

            return View();
        }        
    }
}

