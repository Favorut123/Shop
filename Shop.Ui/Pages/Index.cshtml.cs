﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.CreateProducts;
using Shop.Application.GetProducts;
using Shop.DataBase;

namespace Shop.Ui.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _ctx;
 
        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty] //in razorViews basically says: this right here is my Main module 
        public Application.CreateProducts.ProductViewModel Product { get; set; }

        public IEnumerable<Application.GetProducts.ProductViewModel> Products { get; set; }
        public void OnGet()
        {
            Products = new GetProducts(_ctx).Do();
        }

        //razor back-end
        public async Task<IActionResult> OnPost()
        {
            await new CreateProduct(_ctx).Do(Product);

            return RedirectToPage("Index");
        }
    }
}
