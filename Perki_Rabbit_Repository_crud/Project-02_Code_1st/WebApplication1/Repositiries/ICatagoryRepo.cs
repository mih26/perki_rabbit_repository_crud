using WebApplication1.Models;

namespace WebApplication1.Repositiries
{
    public interface ICatagoryRepo
    {
        Task<IEnumerable<Catagory>> GetAsync();
        Task<Catagory> GetAsync(int id);
        Task InsertAsync(Catagory catagory);
        Task UpdateAsync(Catagory catagory);
        Task DeleteAsync(Catagory catagory);
        Task CompleteAsync();
    }
}
