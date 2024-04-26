using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FakeStore.Models;
using FakeStore.Interfaces;
using FakeStore.Services;

namespace FakeStore.Controllers;

public class HomeController : Controller
{
    private readonly IAPIService _APIService;

    public HomeController(IAPIService apiService)
    {
        _APIService = apiService;
    }

    public async Task<IActionResult> Index(string searchString)
    {
        var products = from product in await _APIService.GetProducts() select product;
        if (!String.IsNullOrEmpty(searchString))
        {
            products = products.Where(search => search.category!.Contains(searchString));
        }
        return View(products.ToList());
    }

    [HttpPost]
    public string Index(string searchString, bool notUsed)
    {
        return "From [HttpPost]Index: filter on " + searchString;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
