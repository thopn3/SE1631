using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_NorthwindProject.Models;
using REST_API_NorthwindProject.DTO;
using System.Diagnostics.Eventing.Reader;

namespace REST_API_NorthwindProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SE1631_DBContext _context;
        public ProductsController(SE1631_DBContext context)
        {
            _context = context;
        }

        #region DTO

        //// R: Read all Products
        //// GET - URI: /products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            List<Product> products = await _context.Products.Include(p => p.Category).ToListAsync();
            if (products == null)
            {
                return NotFound();
            }
            var config = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
            var mapper = config.CreateMapper();
            List<ProductDTO> result = products.Select(p => mapper.Map<Product, ProductDTO>(p)).ToList();
            return Ok(result);
        }

        //// R: Read single Product by Id
        [HttpGet("{id}")]
        //// GET - URI: /products/1
        public async Task<ActionResult<Product>> GetProductById(long id)
        {
            Product? product = await _context.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            var config = new MapperConfiguration(config => config.AddProfile(new MappingProfile()));
            var mapper = config.CreateMapper();
            ProductDTO result = mapper.Map<Product, ProductDTO>(product);
            return Ok(result);
        }

        //// C: Create a new Product
        //// POST - URI: /products
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product p)
        {
            if (!CategoryExists(p.CategoryId))
            {
                return BadRequest();
            }
            if (_context.Products == null)
                return Problem("Entity set 'Products' is null");
            _context.Products.Add(p);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = p.ProductId }, p);
        }

        // U: Update a single Product
        // PUT - URI: /products/1
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // Check existing Category by CategoryId
        private bool CategoryExists(int id)
        {
            return (_context.Categories?.Any(c => c.CategoryId == id)).GetValueOrDefault();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(p => p.ProductId == id)).GetValueOrDefault();
        }

        #endregion
    }
}
