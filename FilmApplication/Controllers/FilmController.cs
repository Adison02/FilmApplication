using System.Diagnostics;
using FilmApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmApplication.Controllers;

public class FilmController : Controller
{
    private static IList<FilmModel> Films = new List<FilmModel>
    {
        new() { ID = 1, Title = "The Shawshank Redemption", Description = "The Shawshank Redemption", Price = 9},
        new() { ID = 2, Title = "The Godfather", Description = "The Godfather", Price = 4},
        new() { ID = 3, Title = "The Dark Knight", Description = "The Dark Knight", Price = 14},
    };

    public IActionResult Index()
    {
        return View(Films);
    }

    public IActionResult Details(int id)
    {
        var film = Films.FirstOrDefault(x => x.ID.Equals(id));
        
        if (film is null)
            return NotFound();

        return View(film);
    }

    public IActionResult Delete(int id)
    {
        var film = Films.FirstOrDefault(x => x.ID.Equals(id));
        
        if (film is null)
            return NotFound();

        Films.Remove(film);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var film = Films.FirstOrDefault(x => x.ID.Equals(id));
        
        if (film is null)
            return NotFound();

        return View(film);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, FilmModel newModel)
    {
        FilmModel model = Films.FirstOrDefault(x => x.ID.Equals(id));

        if (model is null)
            return NotFound();

        model.Title = newModel.Title;
        model.Description = newModel.Description;
        model.Price = newModel.Price;

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Create()
    {
        return View(new FilmModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(FilmModel model)
    {
        model.ID = Films.Max(x => x.ID) + 1;
        Films.Add(model);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}