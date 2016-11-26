using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DojoPuzzles.Models;

namespace DojoPuzzles.Controllers
{
    public class FizzBuzzController : Controller
    {
        // GET: FizzBuzz
        private static FizzBuzz _fizzBuzz = new FizzBuzz();

        public ActionResult FizzBuzz()
        {
            return View(_fizzBuzz.listFizzBuzz);
        }

        public ActionResult FizzBuzzCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FizzBuzzCreate(FizzBuzzModels _fizzBuzzModels)
        {
            _fizzBuzz.calcular(_fizzBuzzModels);
            return View();
        }
    }
}