using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
    public class Catagory : EntityBase
    {
        [Required, StringLength(50)]
        public string CatagoryName { get; set; } = default!;
        [Required, StringLength(150)]
        public string Description { get; set; } = default!;
        public virtual ICollection<Catagory> Catagories { get; set; } = new List<Catagory>();

    }
    public class Product : EntityBase
    {
        [Required, StringLength(50)]
        public string ProductName { get; set; } = default!;
        [Required, Column(TypeName ="money")]
        public decimal UnitPrice { get; set; }
        [ForeignKey("Catagory")]
        public int CatagoryId { get; set; }
        public virtual Catagory Catagory { get; set; } = default!;
    }
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        public DbSet<Catagory> Catagories { get; set;  }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catagory>().HasData(
                new Catagory { Id = 1, CatagoryName = "c1", Description = "Baby Foot" }
                );
            modelBuilder.Entity<Product>().HasData(
               new Product { Id = 1, ProductName = "p1", UnitPrice = 145.00M, CatagoryId=1 }
               );
        }
    }
}
