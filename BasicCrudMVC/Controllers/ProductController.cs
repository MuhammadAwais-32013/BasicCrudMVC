using BasicCrudMVC.Models;
using BasicCrudMVC.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrudMVC.Controllers
{
    public class ProductController : Controller
    {
        // Add Depedency injection => why required 

        private readonly ApplicationDBContext _context;

        public ProductController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            var products = _context.Products.ToList<Product>();
            return View(products);
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
        public ActionResult Create(AddProduct addproduct)
        {
            try
            {
                Product product = new Product()
                {
                    Name = addproduct.Name,
                    Description = addproduct.Description,
                    Price = addproduct.Price,
                    Stock = addproduct.Stock

                };
                _context.Products.Add(product);
                _context.SaveChanges();
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {   var product= _context.Products.SingleOrDefault(p => p.Id == id);
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                var dbproduct = _context.Products.SingleOrDefault(p => p.Id == product.Id);
                if (dbproduct != null)
                {
                    dbproduct.Name = product.Name;
                    dbproduct.Description = product.Description;
                    dbproduct.Price = product.Price;
                    dbproduct.Stock = product.Stock;
                    _context.SaveChanges();
                   
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
      

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product product)
        {
            try
            {
                Product dbproduct = _context.Products.SingleOrDefault(p => p.Id == product.Id);
                _context.Remove(dbproduct);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
