using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositiries
{
    public class ProductRepo : IProductRepo
    {
        private readonly ProductDbContext db;
        public ProductRepo(ProductDbContext db)
        {
            this.db = db;
        }
        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            db.Products.Remove(product);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await db.Products.FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Catagory>> GetCatagoriesAsync()
        {
            return await db.Catagories.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetWithIncludeAsync()
        {
            return await db.Products.Include(p=> p.Catagory).ToListAsync();         
        }

        public Task InsertAsync(Product product)
        {
            return db.Products.AddRangeAsync(product);
        }

        public Task UpdateAsync(Product product)
        {
            db.Entry(product).State= EntityState.Modified;
            return Task.CompletedTask;
        }

        //Task<Product> IProductRepo.GetAsync(int id)
        //{
        //    return await db.Products.FirstAsync(x => x.Id == id);
        //}
    }
}
