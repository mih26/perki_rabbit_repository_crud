using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositiries;

namespace WebApplication1.Controllers
{
    public class CatagoriesController : Controller
    {
        readonly ICatagoryRepo repo;
        public CatagoriesController(ICatagoryRepo repo)
        {
            this.repo = repo;
        }

        public async Task <IActionResult> Index()
        {
            return View(await repo.GetAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Catagory catagory)
        {
            if(ModelState.IsValid)
            {
                await repo.InsertAsync(catagory);
                await repo.CompleteAsync();
                return RedirectToAction("Index");
            }
            return View(catagory);
        }
        public async Task <IActionResult> Edit(int id)
        {
            return View(await repo.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                await repo.UpdateAsync(catagory);
                await repo.CompleteAsync();
                return RedirectToAction("Index");
            }
            return View(catagory);
        }
        public async Task<IActionResult> Delete(int id)
        {
            return View(await repo.GetAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Catagory catagory)
        {
                await repo.DeleteAsync(catagory);
                await repo.CompleteAsync();
                return RedirectToAction("Index"); 
        }
    }
}
