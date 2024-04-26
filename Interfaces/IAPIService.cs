using FakeStore.Models;

namespace FakeStore.Interfaces;

public interface IAPIService
{
  Task<List<Product>> GetProducts();
  Task<Product> GetProduct(long idProduct);
}