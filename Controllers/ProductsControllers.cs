using System;
using ProductsCRUD.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsCRUD.Data;
using ProductsCRUD.Data.Models;
using IProductsCRUD.Controllers;

namespace ProductsCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsControllers : ControllerBase, IProductsControlers
    {

        public ProductsControllers(AppDbContext db)
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
        public async Task<IActionResult> GetProductsById()
        {
            var p = await _db.Products.ToListAsync();
            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(string productCRUD)
        {
            ProductCRUD p = new() { Name = productCRUD };
            await _db.Products.AddAsync(p);
            _db.SaveChanges();
            return Ok(p);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateProduct(ProductCRUD product)
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
            _db.SaveChanges();
            return Ok(p);
        }
    }
}