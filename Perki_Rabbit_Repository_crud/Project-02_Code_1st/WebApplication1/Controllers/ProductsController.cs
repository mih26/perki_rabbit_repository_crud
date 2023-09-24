using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Repositiries;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepo repo;
        public ProductsController(IProductRepo repo)
        {
            this.repo = repo;
        }
        public async Task <IActionResult> Index()
        {

            return View(await repo.GetWithIncludeAsync());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Catagories = await repo.GetCatagoriesAsync();
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(ProductInputModel product)
        {
            if(ModelState.IsValid)
            {
                await repo.InsertAsync(new Product
                {
                    CatagoryId = product.CatagoryId,
                    ProductName= product.ProductName,
                    UnitPrice= product.UnitPrice
                });
                await repo.CompleteAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Catagories = await repo.GetCatagoriesAsync();
            return View(product);
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Catagories = await repo.GetCatagoriesAsync();
            var product = repo.GetAsync(id);
            return View(new ProductInputModel
            {
                Id= product.Id,
                ProductName= product.Result.ProductName,
                UnitPrice = product.Result.UnitPrice,
                CatagoryId = product.Result.CatagoryId
            });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductInputModel product)
        {
            if (ModelState.IsValid)
            {
                var existing = await repo.GetAsync(product.Id);
                existing.ProductName = product.ProductName;
                existing.UnitPrice = product.UnitPrice;
                existing.CatagoryId= product.CatagoryId;
                await repo.CompleteAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Catagories = await repo.GetCatagoriesAsync();
            return View(product);
        }
    }
}
