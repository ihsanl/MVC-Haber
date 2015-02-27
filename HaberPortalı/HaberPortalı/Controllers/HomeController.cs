using HaberPortalı.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberPortalı.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        Haberportali db = new Haberportali();
        public ActionResult Index()
        {           
            return View();
        }
        public ActionResult SliderGetir()
        {
            var haberler = db.Habers.Where(x => x.HaberTip.Adi == "Manset").OrderByDescending(x => x.Yayim_Tarihi).Take(5);
            return View(haberler);
        }
        public ActionResult EnsonHaberler()
        {
            var haberler = db.Habers.OrderByDescending(x => x.Yayim_Tarihi).Take(7);
            return View(haberler);
        }
        public ActionResult UstTab()
        {
            return View();
        }
        public ActionResult UstTab_Videogetir()
        {
            var videohaber = db.Habers.Where(x => x.TipID == 2 && x.Videoyol != null).OrderByDescending(x => x.Yayim_Tarihi).Take(8);
            return View(videohaber);
        }
        public ActionResult UstTab_GorusGetir()
        {
            var gorusgetir = db.Gorus.OrderByDescending(x => x.GorusTarihi).Take(2);
            return View(gorusgetir);
        }
        public ActionResult UstTab_AnketGetir()
        {
            if (Session["oylanananket"] != null)
            {
                return View("UstTab_AnketSonucGetir", Session["oylanananket"]);

            }
            else
            {
                //Anket onaylanmamışsa
                HttpCookie anketci = Request.Cookies["anketler"];
                if (anketci == null) anketci = new HttpCookie("anketler");
                string anketcookie = anketci.Value;
                if (anketcookie == null) anketcookie = "0";

                int[] oylananlar = anketcookie.Split(',').Select(x => Convert.ToInt32(x)).ToArray();
                var anketler = db.Ankets.Where(x => x.AktifMi == true && x.SonOyTarihi >= DateTime.Now && !oylananlar.Contains(x.Id)).ToList();
                if (anketler.Any())
                {
                    Random rn = new Random();
                    return View(anketler[rn.Next(0, anketler.Count)]);
                }
                return View("BosAnket");

            }
        }
        public ActionResult OyVer(int Id)
        {
          
           
                int secenekid = Convert.ToInt32(Request.Form["choice"]);
                Anket anket = db.Ankets.FirstOrDefault(x => x.Id == Id);
                AnketSecenek anketsecenek = db.AnketSeceneks.FirstOrDefault(x => x.Id == secenekid);
                anket.Katilimcisayisi++;
                anketsecenek.Oysayisi++;
                db.SaveChanges();
                HttpCookie anketcookie = Request.Cookies["anketler"];
                if (anketcookie != null)
                {
                    anketcookie.Value += "" + Id;
                    Response.Cookies.Add(anketcookie);
                }
                else
                {
                    anketcookie = new HttpCookie("anketler");
                    anketcookie.Value = "0";
                }
                Response.Cookies.Add(anketcookie);
                Session["oylanananket"] = anket;
                return View("Index");
            }

        public ActionResult FotoSliderGetir() {

            var haberler = db.Habers.Where(x => x.HaberTip.Adi == "FotoGaleri").OrderByDescending(x => x.Yayim_Tarihi).Take(6);
            return View(haberler);
        }

       
    }
}