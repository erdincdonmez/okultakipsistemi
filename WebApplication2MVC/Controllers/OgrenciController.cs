using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication2MVC.Models;

namespace WebApplication2MVC.Controllers
{
    public class OgrenciController : Controller
    {
        public IActionResult Index()
        {
            List<Ogrenci> lst;
            using (var ctx = new OkulDbContext())
            {
                if (ctx is not null)
                {
                    lst = ctx.Ogrenciler.ToList();
                    return View(lst);
                }
                else return View();
            }

        }
        [HttpGet]
        public ActionResult OgrenciEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult OgrenciEkle(Ogrenci ogr)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Ogrenciler.Add(ogr);
                var sonuc = ctx.SaveChanges();
                if (sonuc > 0) TempData["Sonuc"] = true;
                else TempData["Sonuc"] = false;
            }
            //return View();
            return RedirectToAction("Index");
        }
        public IActionResult OgrenciSil(int id)
        {
            using (var ctx = new OkulDbContext())
            {
                var ogr = ctx.Ogrenciler.Find(id);
                ctx.Remove(ogr);
                ctx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult OgrenciGuncelle(int id)
        {
            Ogrenci ogr;
            using (var ctx = new OkulDbContext())
            {
                ogr = ctx.Ogrenciler.Find(id);

            }
            return View(ogr);
        }
        [HttpPost]
        public IActionResult OgrenciGuncelle(Ogrenci ogr)
        {
            using (var ctx = new OkulDbContext())
            {
                ctx.Entry(ogr).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        public IActionResult ExtraIslemler()
        {
            return View();
        }
        public ViewResult OgrenciBilgi(int id)
        {
            //List<Ogrenci> ogrenciler = new List<Ogrenci>(
            //    new Ogrenci() { id=1, AdSoyad="Ali AK", TC="qwert123"},
            //    );
            var std1 = new Ogrenci();
            std1.OgrenciId = 1;
            std1.AdSoyad = "Ali Aka";
            std1.TC = "123234123";

            var std2 = new Ogrenci();
            std2.OgrenciId = 2;
            std2.AdSoyad = "Veli Güllü";
            std2.TC = "32659854";

            if (id == 1) ViewData["ogrenci"] = std1;
            if (id == 2) ViewData["ogrenci"] = std2;
            if (id == 3) ViewData["ogrenci"] = null;

            return View();
        }
        public ViewResult OgrenciBilgi1(int id)
        {
            var std1 = new Ogrenci();
            std1.OgrenciId = 1;
            std1.AdSoyad = "Ali Aka";
            std1.TC = "123234123";

            var std2 = new Ogrenci();
            std2.OgrenciId = 2;
            std2.AdSoyad = "Veli Güllü";
            std2.TC = "32659854";

            if (id == 1) ViewBag.Student = std1;
            if (id == 2) ViewBag.Student = std2;
            if (id == 3) ViewBag.Student = null;

            return View();
        }
        public ViewResult OgrenciBilgi2(int id)
        {

            var std1 = new Ogrenci();
            std1.OgrenciId = 1;
            std1.AdSoyad = "Ali Aka";
            std1.TC = "123234123";

            var std2 = new Ogrenci();
            std2.OgrenciId = 2;
            std2.AdSoyad = "Veli Güllü";
            std2.TC = "32659854";

            var ogr = new Ogrenci();

            if (id == 1) ogr = std1;
            if (id == 2) ogr = std2;
            if (id == 3) ogr = null;

            return View(ogr);
        }
        public ViewResult OgrenciOgretmenBilgi(int id)
        {

            var std1 = new Ogrenci();
            std1.OgrenciId = 1;
            std1.AdSoyad = "Ali Aka";
            std1.TC = "123234123";

            var std2 = new Ogrenci();
            std2.OgrenciId = 2;
            std2.AdSoyad = "Veli Güllü";
            std2.TC = "32659854";

            var ogr = new Ogrenci();

            var ogrt1 = new Ogretmen();
            ogrt1.Ogretmenid = 1;
            ogrt1.AdSoyad = "Ali Akaö";
            ogrt1.Brans = "123234123ö";

            var ogrt2 = new Ogretmen();
            ogrt2.Ogretmenid = 2;
            ogrt2.AdSoyad = "Veli Güllüö";
            ogrt2.Brans = "32659854ö";

            var ogrt = new Ogrenci();

            var OO = new infoDTO(std1, ogrt1);

            if (id == 1) OO = new infoDTO(std1, ogrt1);
            if (id == 2) OO = new infoDTO(std2, ogrt1);
            if (id == 3) OO = null;

            return View(OO);
        }
    }
}
