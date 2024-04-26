using FakeStore.Models;

namespace FakeStore.Interfaces;

public interface IAPIService
{
  Task<List<Product>> GetProducts();
  Task<Product> GetProduct(long idProduct);
  Task<bool> SaveProduct(Product obj);
  Task<bool> EditProduct(Product obj);
  Task<bool> DeleteProduct(long idProduct);
}