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
            decimal DiscountedNettoPrice = product.UnitNettoPrice * (1 - product.IndividualDiscount / 100);

            if(product.Quantity > 100)
            {
                DiscountedNettoPrice *= (1 - product.QuantityDiscount / 100);
            }

            decimal TotalNettoPrice = DiscountedNettoPrice * product.Quantity;

            decimal TotaBruttoPrice;
            if(product.IsRetailCustomer)
            {
                // ��� ���������� �볺��� ��� ������������ �� ������
                TotaBruttoPrice = TotalNettoPrice * (1 + product.VAT / 100);
            }
            else
            {
                // ��� �������������� �볺��� ��� ������������ �� �����
                TotaBruttoPrice = TotalNettoPrice * (TotalNettoPrice * product.VAT / 100);
            }
            ViewBag.TotalNettoPrice = TotalNettoPrice;
            ViewBag.TotalBruttoPrice = TotaBruttoPrice;

            return View(product);
        }
    }
}