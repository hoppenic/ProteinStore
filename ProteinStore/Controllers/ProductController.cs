using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProteinStore.Models;


namespace ProteinStore.Controllers
{
    public class ProductController : Controller
    {
        private List<Product> _products;

        public ProductController()
        {
            _products = new List<Product>();
            _products.Add(new Product
            {
                ID=1,
                Name="Whey Protein",
                Description="Whey",
                Price=15.99m,
                Image=""

            });

            _products.Add(new Product
            {
                ID = 2,
                Name = "Egg White Protein",
                Description = "Egg",
                Price = 19.99m,
                Image = ""

            });

            _products.Add(new Product
            {
                ID = 3,
                Name = "Beef Protein",
                Description = "Beef",
                Price = 23.99m,
                Image = ""

            });

            
        }

        public IActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                Product p = _products.Single(x => x.ID == id.Value);
                return View(p);
            }
            return NotFound();
        }



        public IActionResult Index()
        {
            return View(_products);
        }
    }
}