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

    public async Task<IActionResult> Index()
    {
        List<Product> list = await _APIService.GetProducts();
        return View(list);
    }

    public async Task<IActionResult> Product(long idProduct)
    {
        Product product_model = new Product();

        ViewBag.Accion = "New product";
        if (idProduct != 0)
        {
            product_model = await _APIService.GetProduct(idProduct);
            ViewBag.Accion = "Edit Product";
        }

        return View(product_model);
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
