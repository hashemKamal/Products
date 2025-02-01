using Microsoft.AspNetCore.Mvc;
using ProductsCRUD.Data.Models;

namespace IProductsCRUD.Controllers
{
    public interface IProductsControlers
    {
        Task<IActionResult> AddProduct(string productCRUD);
        Task<IActionResult> GetProducts();
        Task<IActionResult> UpdateProduct(Product productCRUD);

    }
}
