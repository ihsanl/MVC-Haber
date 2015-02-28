using MvcEmlak.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MvcEmlak.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Üye Model)
        {
            int lastId = 0;
            using (var db = new Entities())
            {
                Model.ÜyelikTarihi = DateTime.Now;
                Model.EPostaDoğrulama = false;
                Model.Şifre = Model.Şifre.GenerateMD5Hex();
                db.Üyeler.Add(Model);
                db.SaveChanges();
                lastId = db.Üyeler.Where(p => p.EPosta == Model.EPosta).SingleOrDefault().Id;
            }

            string key = (lastId.ToString() + ConfigurationManager.AppSettings["securitySalt"]).GenerateMD5Hex();
            string link = ConfigurationManager.AppSettings["siteUrl"] + Url.Action("Validate", "Member") + "?id=" + lastId + "&key=" + key;

            MessageHelper.SendMessage(Model.EPosta, "EPosta Doğrulama Mesajı", string.Format(System.IO.File.ReadAllText(Server.MapPath("~/Content/ValidationMessage.html")), Model.İsim, link));

            return RedirectToAction("RegisterSuccess");
        }

        public ActionResult Validate(int Id, string Key)
        {
            using (var db = new Entities())
            {
                var _üye = db.Üyeler.Find(Id);

                ViewData["status"] = _üye.EPostaDoğrulama = (Id + ConfigurationManager.AppSettings["securitySalt"]).GenerateMD5Hex() == Key;
                db.SaveChanges();
                return View();
            }
        }

        public ActionResult RegisterSuccess()
        {
            return View();
        }

        public ActionResult CheckEMail(string EMail)
        {
            System.Threading.Thread.Sleep(3000);
            using (var db = new Entities())
            {
                var result = db.Üyeler.Where(p => p.EPosta == EMail).Count();
                return Json(new { adet = result }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Login(string EPosta, string Şifre, string returnUrl)
        {
            using (var db = new Entities())
            {
                var _şifre = Şifre.GenerateMD5Hex();
                Session["member"] = db.Üyeler.Where(p => p.EPosta == EPosta && p.Şifre == _şifre && p.EPostaDoğrulama).SingleOrDefault();
                return Redirect(returnUrl);
            }
        }

        public ActionResult LogOut()
        {
            Session["member"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RenewPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RenewPassword(string EPosta)
        {
            using (var db = new Entities())
            {
                var _üye = db.Üyeler.Where(p => p.EPosta == EPosta).SingleOrDefault();
                if (_üye != null)
                {
                    var key = (_üye.Id + ConfigurationManager.AppSettings["securitySalt"]).GenerateMD5Hex();
                    var link = ConfigurationManager.AppSettings["siteUrl"] + Url.Action("RenewForm", "Member") + "?id=" + _üye.Id + "&key=" + key;
                    var message = string.Format(System.IO.File.ReadAllText(Server.MapPath("~/Content/RenewPasswordMessage.html")), link);
                    MessageHelper.SendMessage(_üye.EPosta, "Şifre Yenileme Mesajı", message);
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RenewForm(int Id, string Key)
        {
            if ((Id + ConfigurationManager.AppSettings["securitySalt"]).GenerateMD5Hex() == Key)
            {
                ViewData["Id"] = Id;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult RenewForm(int Id, Üye Model)
        {
            using (var db = new Entities())
            {
                var _üye = db.Üyeler.Find(Id);
                _üye.Şifre = Model.Şifre.GenerateMD5Hex();
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Posts()
        {
            return View();
        }

        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(string Kategori, decimal Fiyat, string Adres, int Şehir, int Tip, string Başlık, HttpPostedFileBase Görsel, int? KonutMetrekare, int? DükkanMetrekare, int? ArsaMetrekare, bool İmarlı, bool Depo, string OdaBilgisi, string KatBilgisi, string IsıtmaSistemi)
        {
            var db = new Entities();

            byte[] _bytes = null;
            if (Görsel != null)
            {
                _bytes = new byte[Görsel.ContentLength];
                Görsel.InputStream.Read(_bytes, 0, Görsel.ContentLength);
            }

            switch (Kategori)
            {
                case "Konut":
                    var _konut = new Konut();
                    _konut.Adres = Adres;
                    _konut.Başlık = Başlık;
                    _konut.Durum = true;
                    _konut.Fiyat = Fiyat;
                    _konut.IsıtmaSistemi = IsıtmaSistemi;
                    _konut.KatBilgisi = KatBilgisi;
                    _konut.Metrekare = KonutMetrekare ?? 0;
                    _konut.OdaBilgisi = OdaBilgisi;
                    _konut.ŞehirId = Şehir;
                    _konut.Tarih = DateTime.Now;
                    _konut.TipId = Tip;
                    _konut.ÜyeId = 7;//((Üye)Session["member"]).Id;
                    _konut.Görsel = _bytes;

                    db.Emlaklar.Add(_konut);
                    db.SaveChanges();
                    break;
                case "Dükkan":
                    var _dükkan = new Dükkan();
                    _dükkan.Adres = Adres;
                    _dükkan.Başlık = Başlık;
                    _dükkan.Durum = true;
                    _dükkan.Fiyat = Fiyat;
                    _dükkan.Metrekare = DükkanMetrekare ?? 0;
                    _dükkan.ŞehirId = Şehir;
                    _dükkan.Tarih = DateTime.Now;
                    _dükkan.TipId = Tip;
                    _dükkan.ÜyeId = ((Üye)Session["member"]).Id;
                    _dükkan.Görsel = _bytes;

                    db.Emlaklar.Add(_dükkan);
                    db.SaveChanges();
                    break;
                case "Arsa":
                    var _arsa = new Arsa();
                    _arsa.Adres = Adres;
                    _arsa.Başlık = Başlık;
                    _arsa.Durum = true;
                    _arsa.Fiyat = Fiyat;
                    _arsa.İmarlı = İmarlı;
                    _arsa.Metrekare = ArsaMetrekare ?? 0;
                    _arsa.ŞehirId = Şehir;
                    _arsa.Tarih = DateTime.Now;
                    _arsa.TipId = Tip;
                    _arsa.ÜyeId = ((Üye)Session["member"]).Id;
                    _arsa.Görsel = _bytes;

                    db.Emlaklar.Add(_arsa);
                    db.SaveChanges();
                    break;
                default:
                    break;
            }
            return RedirectToAction("Posts");
        }
    }
}
