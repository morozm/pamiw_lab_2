using Microsoft.AspNetCore.Mvc;
using zad1.Models;

namespace zad1.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new CalculatorModel());
        }

        [HttpPost]
        public ActionResult Index(CalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                model.Result = model.Number1 + model.Number2;
            }
            return View(model);
        }
    }
}
