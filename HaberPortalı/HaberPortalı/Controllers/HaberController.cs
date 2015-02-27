using HaberPortalı.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberPortalı.Controllers
{
    public class HaberController : Controller
    {
        Haberportali db = new Haberportali();
        // GET: Haber
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Goster(int Id)
        {
            return View(db.Habers.FirstOrDefault(x=>x.Id==Id));
        }
        [HttpPost]
        public ActionResult YorumYap(string txtAdSoyad,string txtEmail,string txtIcerik,int HaberId)
        {

            Yorum yrm = new Yorum();
            yrm.Ad_Soyad = txtAdSoyad;
            yrm.Mail = txtEmail;
            yrm.Icerik = txtIcerik;
            yrm.Baslik = " ";
            yrm.Begeni = 0;
            yrm.Ip = 1;          
            yrm.Tarih = DateTime.Now;
            yrm.Tiksinti = 0;
            yrm.Onayli =true;
            yrm.HaberId = HaberId;
            yrm.GorusID = 1;          
            db.Yorums.Add(yrm); 
            db.SaveChanges();
            return RedirectToAction("Goster", new { Id=HaberId});
        }
        public void YorumBegen(int Id)
        {
            Yorum yrm = db.Yorums.FirstOrDefault(x => x.Id == Id);
            yrm.Begeni++;
            db.SaveChanges();


        }
        public void YorumTiksin(int Id)
        {
            Yorum yrm = db.Yorums.FirstOrDefault(x => x.Id == Id);
            yrm.Tiksinti++;
            db.SaveChanges();


        }
    }
}