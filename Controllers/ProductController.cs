using asp.net_task2.Entities;
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
        public async Task<IActionResult> Index()
        {
            var result = await _productService.GetAllAsync();
            var vm = new ProductListViewModel
            {
                Products = result
            };
            return View(vm);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.GetAllAsync();
            var item = result.SingleOrDefault(e => e.Id == id);
            if (item != null)
            {
                _productService.DeleteAsync(item.Id);
            }
            return RedirectToAction("Index");
        }
        // GET: ProductController/Create
        [HttpGet]
        public IActionResult Add()
        {
            var vm = new ProductAddViewModel
            {
                Product = new Product()
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel vm)
        {
            await _productService.AddAsync(vm.Product);
            return RedirectToAction("Index");
        }


        // GET: ProductController/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            var result = await _productService.GetAllAsync();
            var item = result.SingleOrDefault(e => e.Id == id);
            if (item != null)
            {
                var vm = new ProductUpdateViewModel
                {
                    Product = item
                };
                return View(vm);
            }
            return NotFound();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ProductUpdateViewModel vm)
        {

            await _productService.UpdateAsync(id, vm.Product);
            return RedirectToAction("Index");

        }


    }
}
