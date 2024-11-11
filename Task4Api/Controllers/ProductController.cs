using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task4Api.Dto;
using Task4Api.Model;

namespace Task4Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        Task4DbContext db;
        public ProductController(Task4DbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> products = db.Products.ToList();
            if (products == null) return NotFound();
            List<ProductDto> productsDto = new List<ProductDto>();
            foreach (var item in products)
            {


                ProductDto prod = new ProductDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    amount = item.amount,
                    CatalogId = item.Catalog.Id,
                    CatalogName = item.Catalog.Name
                };
                productsDto.Add(prod);
            }
            return Ok(productsDto);
        }
        [HttpGet("catalog")]
        public IActionResult GetAllCatlog()
        {
          
            return Ok(db.Catalog.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Product item = db.Products.Find(id);
            if(item == null) return NotFound();
           
                ProductDto prod = new ProductDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    amount = item.amount,
                    CatalogId = item.Catalog.Id,
                    CatalogName = item.Catalog.Name
                };
             
            return Ok(prod);
        }
        [HttpGet("ByPrice/{price}")]
        public IActionResult GetByPrice(int price)
        {
            Product item = db.Products.FirstOrDefault(x=>x.Price==price);
            if (item==null)
            {
                return NotFound();
            }

            ProductDto prod = new ProductDto()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                amount = item.amount,
                CatalogId = item.Catalog.Id,
                CatalogName = item.Catalog.Name
            };

            return Ok(prod);
        }
        [HttpPost]
        public IActionResult Add(ProductDto product)
        {
            if(product == null) { return BadRequest(); }
            Product product1 = new Product();
            product1.Id = product.Id;
            product1.Name = product.Name;
            product1.Description = product.Description;
            product1.Price = product.Price;
            product1.amount = product.amount;
            product1.CatalogId = product.CatalogId;
            db.Products.Add(product1);


            db.SaveChanges();
            return CreatedAtAction("GetById", new { id = product.Id }, product);
        }
        [HttpPost("cat")]
        public IActionResult Add(Catalog cat)
        {
            if (cat == null) { return BadRequest(); }
            db.Catalog.Add(cat);
            db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult Edit(ProductDto product)
        {
            if (product == null) { return BadRequest(); }
            Product product1 = db.Products.Find(product.Id);
            if (product1==null)
            {
                return NotFound();
            }
            product1.Id = product.Id;
            product1.Name = product.Name;
            product1.Description = product.Description;
            product1.Price = product.Price;
            product1.amount = product.amount;
            product1.CatalogId = product.CatalogId;
            db.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Product product=db.Products.Find(id);
            if (product==null) { return NotFound(); }
            db.Products.Remove(product);
            db.SaveChanges();
            return Ok();
        }
    }
}
