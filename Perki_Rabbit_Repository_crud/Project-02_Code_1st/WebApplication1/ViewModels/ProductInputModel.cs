using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class ProductInputModel : EntityBase
    {
        [Required, StringLength(50)]
        public string ProductName { get; set; } = default!;
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int CatagoryId { get; set; }
        
    }
}
