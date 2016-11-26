using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DojoPuzzles.Models;

namespace DojoPuzzles.Controllers
{
    public class BissextoController : Controller
    {
        // GET: Bissexto
        private static Bissexto _bissexto = new Bissexto();

        public ActionResult Bissexto()
        {
            return View(_bissexto.listBissexto);
        }

        public ActionResult BissextoCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BissextoCreate(BissextoModels _bissextoModels)
        {
            _bissexto.calcular(_bissextoModels);
            return View();
        }
    }
}