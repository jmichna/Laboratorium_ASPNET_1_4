using Laboratorium_2.Models;
using Microsoft.AspNetCore.Mvc;

//1. wysłanie żądania do formularza (potrzebna akcja w kontrolerze do formularza).
//2. użytkownik wypełnia formularz i submit.
//3. wysyłanie żądania z danymi formularza (potrzebna akcja odbierająca dane - już mamy akcję - calculator).
//4. obliczenie i zwrócenie widoku z wynikami.


namespace Laboratorium_2.Controllers
{
    public enum Operators
    {
        ADD, SUB, MUL, DIV
    }

    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        //public IActionResult Result([FromQuery(Name = "operator")] Operators op, double? x, double? y)
        //{
        //    if (x == null || y == null)
        //    {
        //        return View("Error");
        //    }

        //    switch (op)
        //    {
        //        case Operators.ADD:
        //            ViewBag.result = x + y;
        //            break;
        //        case Operators.SUB:
        //            ViewBag.result = x - y;
        //            break;
        //        case Operators.MUL:
        //            ViewBag.result = x * y;
        //            break;
        //        case Operators.DIV:
        //            ViewBag.result = x / y;
        //            break;
        //        default:
        //            return View("Error");
        //    }

        //    return View();
        //}

        public IActionResult Result(Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }
    }
}
