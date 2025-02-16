using Microsoft.AspNetCore.Mvc;
using Products.Data.Models;

namespace IProducts.Controllers
{
    public interface IProductsController
    {
        Task<IActionResult> AddProduct(string productCRUD);
        Task<IActionResult> GetProducts();
        Task<IActionResult> GetProductById(int id);
        Task<IActionResult> UpdateProduct(Product productCRUD);

    }
}
