using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositiries
{
    public class CatagoryRepo : ICatagoryRepo
    {
        ProductDbContext db;
        public CatagoryRepo(ProductDbContext db)
        {
            this.db = db;
        }

        public async Task CompleteAsync()
        {
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Catagory catagory)
        {
            db.Catagories.Remove(catagory);
            //db.Entry(catagory).State = EntityState.Deleted;
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Catagory>> GetAsync()
        {
            return await db.Catagories.ToListAsync();
        }

        public async Task<Catagory> GetAsync(int id)
        {
            return await db.Catagories.FirstAsync(x=> x.Id== id);
        }

        public Task InsertAsync(Catagory catagory)
        {
            return db.Catagories.AddRangeAsync(catagory);
        }

        public async Task UpdateAsync(Catagory catagory)
        {
            db.Entry(catagory).State= EntityState.Modified;
            await Task.CompletedTask;
        }

        //public Task UpdateAsync(Catagory catagory)
        //{
        //    return db.Catagories.First<Catagory>();
        //}
    }
}
