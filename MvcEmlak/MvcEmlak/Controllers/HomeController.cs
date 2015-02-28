using MvcEmlak.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEmlak.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetImage(int Id)
        {
            var _bytes = new Entities().Emlaklar.Find(Id).Görsel;
            return File(_bytes ?? (System.IO.File.ReadAllBytes(Server.MapPath("~/Content/Images/no-image.jpg"))), "image/jpeg");
        }

        public ActionResult Detay(int Id, string Kategori)
        {
            switch (Kategori)
            {
                case "Konut":
                    var _konut = new Entities().Emlaklar.OfType<Konut>().Where(p => p.Id == Id).SingleOrDefault();
                    return View("KonutDetay", _konut);
                    break;
                case "Dükkan":
                    var _dükkan = new Entities().Emlaklar.OfType<Dükkan>().Where(p => p.Id == Id).SingleOrDefault();
                    return View("DukkanDetay", _dükkan);
                    break;
                case "Arsa":
                    var _arsa = new Entities().Emlaklar.OfType<Arsa>().Where(p => p.Id == Id).SingleOrDefault();
                    return View("ArsaDetay", _arsa);
                    break;
                default:
                    return RedirectToAction("Index", "Home");
                    break;
            }
        }

        [HttpPost]
        public ActionResult Search(int Şehir, string Kategori, decimal? Fiyat1, decimal? Fiyat2, int Tip)
        {
            switch (Kategori)
            {
                case "Konut":
                    var _konutlar = new Entities().Emlaklar.OfType<Konut>().ToList<Emlak>();
                    if (Şehir != -1)
                        _konutlar = _konutlar.Where(p => p.ŞehirId == Şehir).ToList();
                    if (Tip != -1)
                        _konutlar = _konutlar.Where(p => p.TipId == Tip).ToList();
                    if (Fiyat1 != null && Fiyat2 != null)
                        _konutlar = _konutlar.Where(p => p.Fiyat > Fiyat1 && p.Fiyat < Fiyat2).ToList();
                    return View(_konutlar);
                    break;
                case "Dükkan":
                    var _dükkanlar = new Entities().Emlaklar.OfType<Dükkan>().ToList<Emlak>();
                    if (Şehir != -1)
                        _dükkanlar = _dükkanlar.Where(p => p.ŞehirId == Şehir).ToList();
                    if (Tip != -1)
                        _dükkanlar = _dükkanlar.Where(p => p.TipId == Tip).ToList();
                    if (Fiyat1 != null && Fiyat2 != null)
                        _dükkanlar = _dükkanlar.Where(p => p.Fiyat > Fiyat1 && p.Fiyat < Fiyat2).ToList();
                    return View(_dükkanlar);
                    break;
                case "Arsa":
                    var _arsalar = new Entities().Emlaklar.OfType<Arsa>().ToList<Emlak>();
                    if (Şehir != -1)
                        _arsalar = _arsalar.Where(p => p.ŞehirId == Şehir).ToList();
                    if (Tip != -1)
                        _arsalar = _arsalar.Where(p => p.TipId == Tip).ToList();
                    if (Fiyat1 != null && Fiyat2 != null)
                        _arsalar = _arsalar.Where(p => p.Fiyat > Fiyat1 && p.Fiyat < Fiyat2).ToList();
                    return View(_arsalar);
                    break;
                default:
                    return RedirectToAction("Index", "Home");
                    break;
            }

        }

        public ActionResult Detay()
        {



        }



    }
}
