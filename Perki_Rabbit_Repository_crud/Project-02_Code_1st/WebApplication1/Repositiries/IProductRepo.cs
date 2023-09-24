using WebApplication1.Models;

namespace WebApplication1.Repositiries
{
    public interface IProductRepo
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<IEnumerable<Product>> GetWithIncludeAsync();
        Task<IEnumerable<Catagory>> GetCatagoriesAsync();
        Task<Product> GetAsync(int id);
        Task InsertAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
        Task CompleteAsync();
    }
}
