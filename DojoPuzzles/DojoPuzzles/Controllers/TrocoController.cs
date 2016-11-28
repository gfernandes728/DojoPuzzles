using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DojoPuzzles.Models;

namespace DojoPuzzles.Controllers
{
    public class TrocoController : Controller
    {
        // GET: Troco
        private static Troco _troco = new Troco();

        public ActionResult Troco()
        {
            return View(_troco.listTroco);
        }

        public ActionResult TrocoCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TrocoCreate(TrocoModels _trocoModels)
        {
            _troco.calcular(_trocoModels);
            return View();
        }
    }
}