using HaberPortalı.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberPortalı.Controllers
{
    public class GaleriController : Controller
    {
        Haberportali db = new Haberportali();
        // GET: Galeri
        public ActionResult Index()
        {
            return View(db.Habers.Where(x=>x.HaberTip.Adi=="FotoGaleri").OrderByDescending(x=>x.Yayim_Tarihi));
        }


        public ActionResult GaleriGoruntule(int Id)
        {
            var haber = db.Habers.FirstOrDefault(x=>x.Id==Id);
            return View();

        }
    }
}