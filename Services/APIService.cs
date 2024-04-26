// using Newtonsoft.Json;
using System.Text.Json;

using FakeStore.Interfaces;
using FakeStore.Models;

namespace FakeStore.Services;

public class APIService : IAPIService
{
  private static string _baseUrl = "https://fakestoreapi.com/";

  public async Task<List<Product>> GetProducts()
  {
    List<Product> list = new List<Product>();
    var client = new HttpClient();
    client.BaseAddress = new Uri(_baseUrl);

    try
    {
      var response = await client.GetAsync("products/");

      if (response.IsSuccessStatusCode)
      {
        var json_response = response.Content.ReadAsStringAsync().Result;
        var result = JsonSerializer.Deserialize<List<Product>>(json_response);
        list = result;
      }

      return list;
    }
    catch (System.Exception)
    {

      throw;
    }
  }

  public async Task<Product> GetProduct(long idProduct)
  {
    Product obj = new Product();
    var client = new HttpClient();
    client.BaseAddress = new Uri(_baseUrl);

    try
    {
      var response = await client.GetAsync($"products/{idProduct}");

      if (response.IsSuccessStatusCode)
      {
        var json_response = response.Content.ReadAsStringAsync().Result;
        Product result = JsonSerializer.Deserialize<Product>(json_response);
        obj = result;
      }

      return obj;
    }
    catch (System.Exception Error)
    {
      Console.WriteLine(Error);
      return obj;
    }
  }
}