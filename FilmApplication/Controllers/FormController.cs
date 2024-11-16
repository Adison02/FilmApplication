using FilmApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmApplication.Controllers;

public class FormController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(DataModel model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index", "Film", new { firstName = model.FirstName });
        }
        return View(model);
    }
}