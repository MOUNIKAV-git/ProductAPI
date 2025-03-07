using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;


namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductsController(AppDbContext Context)
        {
            _context = Context;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] string? Code, [FromQuery] int PageNumber = 1, [FromQuery] int PageSize = 10)
        {

            if (PageNumber <= 0)
            {
                PageNumber = 1;
            }
            if (PageSize <= 0)
            {
                PageSize = 10;
            }
            var query = _context.Products.AsQueryable();
            if (!String.IsNullOrEmpty(Code))
            {
                query = query.Where(p => p.Code.Contains(Code));
            }
            var totalItems = await query.CountAsync();
            var products   = await query.Skip(PageNumber - 1 * PageSize).Take(PageSize).ToListAsync();
            var response = new
            {
                TotalItems = totalItems,
                PageNumber = PageNumber,
                PageSize = PageSize,
                Products = products
            };
            return Ok(response);
        }

    }
}
