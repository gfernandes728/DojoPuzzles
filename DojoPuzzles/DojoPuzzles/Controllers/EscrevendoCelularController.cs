using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DojoPuzzles.Models;

namespace DojoPuzzles.Controllers
{
    public class EscrevendoCelularController : Controller
    {
        // GET: EscrevendoCelular
        private static EscrevendoCelular _escrevendoCelular = new EscrevendoCelular();

        public ActionResult EscrevendoCelular()
        {
            return View(_escrevendoCelular.listEscrevendoCelular);
        }

        public ActionResult EscrevendoCelularCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EscrevendoCelularCreate(EscrevendoCelularModels _escrevendoCelularModels)
        {
            _escrevendoCelular.calcular(_escrevendoCelularModels);
            return View();
        }
    }
}