using System;
using Products.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.Data;
using Products.Data.Models;
using IProducts.Controllers;

namespace Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase, IProductsController
    {

        public ProductsController(AppDbContext db)
        {
            _db = db;
        }
        private readonly AppDbContext _db;

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var p = await _db.Products.ToListAsync();
            return Ok(p);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProductById(int id)
        {

            var p = await _db.Products.SingleOrDefaultAsync(p => p.Id == id);
            //var p = await _db.Products.Where(p => p.Id == id).FirstAsync();
            // select * from product where id = 5
            // lamda expression
            //var p =  _db.Products.ToList().Where(item => item.Id == id).First();
            // select * from product
            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(string productName)
        {
            Product p = new() { Name = productName };
            await _db.Products.AddAsync(p);
            _db.SaveChanges();
            return Ok(p);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var p = await _db.Products.SingleOrDefaultAsync(p => p.Id == product.Id);
            if (p == null)
            {
                return NotFound($"Product Id {product.Id} Not Exist! ");
            }
            p.Name = product.Name;
            _db.SaveChanges();
            return Ok(p);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var p = await _db.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (p == null)
            {
                return NotFound($"Product Id {id} Not Exist! ");
            }
            _db.Products.Remove(p);
           // delete product where id = 5
            _db.SaveChanges();
            return Ok(p);
        }
    }
}