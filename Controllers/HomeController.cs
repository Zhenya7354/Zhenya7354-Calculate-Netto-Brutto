using Lab_1._IO.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab_1._IO.Controllers
{
    public class HomeController : Controller
    {
        

        

        public IActionResult Index(Product product)
        {
            
            return View(product);
        }

        public IActionResult Calculate(Product product)
        {
            decimal DiscountedNettoPrice = 0;
            if (product.IndividualDiscount == 10)
            {
                 DiscountedNettoPrice = product.UnitNettoPrice * (1 - product.IndividualDiscount / 100);
            }
            else
            {
                 DiscountedNettoPrice = product.UnitNettoPrice;
            }
            if(product.Quantity > 100)
            {
                product.QuantityDiscount = 2;
                DiscountedNettoPrice *= (1 - product.QuantityDiscount / 100);
            }

            decimal TotalNettoPrice = DiscountedNettoPrice * product.Quantity;

            decimal TotaBruttoPrice;
            if(product.IsRetailCustomer)
            {
                // Для роздрібного клієнта ПДВ обчислюється від брутто
                TotaBruttoPrice = TotalNettoPrice / (1 - product.VAT / 100);
            }
            else
            {
                // Для інституційного клієнта ПДВ обчислюється від нетто
                TotaBruttoPrice = TotalNettoPrice * (1 + product.VAT / 100);
            }
            ViewBag.TotalNettoPrice = TotalNettoPrice;
            ViewBag.TotalBruttoPrice = TotaBruttoPrice;

            return View(product);
        }
    }
}
