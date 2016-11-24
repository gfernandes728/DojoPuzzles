using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DojoPuzzles.Models;

namespace DojoPuzzles.Controllers
{
    public class CollatzController : Controller
    {
        // GET: Collatz
        private static Collatz _collatz = new Collatz();

        public ActionResult Collatz()
        {
            return View(_collatz.listCollatz);
        }

        public ActionResult CollatzCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CollatzCreate(CollatzModels _collatzModels)
        {
            _collatz.calcular(_collatzModels);
            return View();
        }
    }
}