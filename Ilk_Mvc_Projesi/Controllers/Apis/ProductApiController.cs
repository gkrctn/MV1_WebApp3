using Ilk_Mvc_Projesi.Models;
using Ilk_Mvc_Projesi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ilk_Mvc_Projesi.Controllers.Apis
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ProductApiController(NorthwindContext context)
        {
            _context = context;
        }
        public IActionResult Add(ProductViewModel model)
        {
            var product = new Product()
            {
                CategoryId = model.CategoryId,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice
            };
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(new
                {
                    Message = "Ürün ekleme başarılı",
                    Model = product
                });
            }
            catch(Exception ex)
            {
                return BadRequest($"Bir hata oluştu : {ex.Message}");
            }





        }

        [Route("~/api/product")]
        public IActionResult Delete(int id = 0)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
                return NotFound("Ürün Bulunamadı");
            try
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok(new
                {
                    Message = $"{product.ProductName} isimli ürün başarıyla silindi"
                });
            }
            catch (Exception ex)
            {

                return BadRequest($"Bir hata oluştu:{ex.Message}");
            }
        }


    }
}
