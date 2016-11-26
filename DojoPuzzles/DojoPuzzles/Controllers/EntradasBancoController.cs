using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DojoPuzzles.Models;

namespace DojoPuzzles.Controllers
{
    public class EntradasBancoController : Controller
    {
        // GET: EntradasBanco
        private static EntradasBanco _entradasBanco = new EntradasBanco();

        public ActionResult EntradasBanco()
        {
            _entradasBanco.readLog();
            return View(_entradasBanco.listEntradasBanco);
        }


        public ActionResult EntradasBancoCreate()
        {
            ViewData["getOpenDoor"] = _entradasBanco.getOpenDoor();
            return View();
        }

        [HttpPost]
        public ActionResult EntradasBancoCreate(EntradasBancoModels _entradasBancoModels)
        {
            _entradasBanco.calcular(_entradasBancoModels);
            ViewData["getOpenDoor"] = _entradasBanco.getOpenDoor();
            return View();
        }
    }
}