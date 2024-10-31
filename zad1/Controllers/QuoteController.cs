using Microsoft.AspNetCore.Mvc;
using zad1.Models;
using System.Collections.Generic;

namespace QuotesApp.Controllers
{
    public class QuotesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
