﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaberPortalı.Controllers
{
    public class AramaController : Controller
    {
        // GET: Arama
        public ActionResult Ara(string txtAra)
        {
            return View();
        }
    }
}