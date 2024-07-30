using asp.net_task2.Models;
using asp.net_task2.Services;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_task2.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index(string key = "")
        {
            var result = await _productService.GetAllByKeyAsync(key);
            var vm = new ProductListViewModel
            {
                Products = result
            };
            return View(vm);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.GetAllByKeyAsync("");
            var item = result.SingleOrDefault(e => e.Id == id);
            if (item != null)
            {
                _productService.DeleteAsync(item.Id);
            }
            return RedirectToAction("Index");
        }
        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
