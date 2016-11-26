using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DojoPuzzles.Models;

namespace DojoPuzzles.Controllers
{
    public class EstatisticasController : Controller
    {
        // GET: Estatisticas
        private static Estatisticas _estatisticas = new Estatisticas();

        public ActionResult Estatisticas()
        {
            return View(_estatisticas.listEstatisticas);
        }

        public ActionResult EstatisticasCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EstatisticasCreate(EstatisticasModels _estatisticasModels)
        {
            _estatisticas.calcular(_estatisticasModels);
            return View();
        }
    }
}