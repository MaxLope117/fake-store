using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Collections.Generic;

using FakeStore.Interfaces;
using FakeStore.Models;

namespace FakeStore.Services;

public class APIService : IAPIService
{
  private static string _baseUrl = "https://fakestoreapi.com/";

  public async Task<List<Product>> ProductsList()
  {
    List<Product> list = new List<Product>();
    var client = new HttpClient();
    client.BaseAddress = new Uri(_baseUrl);

    try
    {
      var response = await client.GetAsync("products/");

      if (response.IsSuccessStatusCode)
      {
        var json_response = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject(json_response);
        Console.WriteLine(result.GetType());
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
      var response = await client.GetAsync($"product/{idProduct}");

      if (response.IsSuccessStatusCode)
      {
        var json_response = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<APIResult>(json_response);
        obj = result.obj;
      }

      return obj;
    }
    catch (System.Exception Error)
    {
      Console.WriteLine(Error);
      return obj;
    }
  }

  public Task<bool> SaveProduct(Product obj)
  {
    throw new NotImplementedException();
  }

  public Task<bool> EditProduct(Product obj)
  {
    throw new NotImplementedException();
  }

  public Task<bool> DeleteProduct(long idProduct)
  {
    throw new NotImplementedException();
  }

}