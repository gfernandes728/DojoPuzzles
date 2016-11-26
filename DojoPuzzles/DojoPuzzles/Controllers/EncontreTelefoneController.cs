using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DojoPuzzles.Models;

namespace DojoPuzzles.Controllers
{
    public class EncontreTelefoneController : Controller
    {
        // GET: EncontreTelefone
        private static EncontreTelefone _encontreTelefone = new EncontreTelefone();

        public ActionResult EncontreTelefone()
        {
            return View(_encontreTelefone.listEncontreTelefone);
        }

        public ActionResult EncontreTelefoneCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EncontreTelefoneCreate(EncontreTelefoneModels _encontreTelefoneModels)
        {
            _encontreTelefone.calcular(_encontreTelefoneModels);
            return View();
        }
    }
}