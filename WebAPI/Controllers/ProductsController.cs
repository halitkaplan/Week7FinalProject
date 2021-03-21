using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]     
    [ApiController]         //---------> C#'ta ATTRIBUTE : BİR CLASS İLE İLGİLİ BİLGİ VERME, İMZALAMA
                            // Bu class bir Controller'dir, kendini ona göre yapılandır diyoruz.
                            // --------> JAVA'da ANOOTATION
    public class ProductsController : ControllerBase
    {

        //Loosely coupled -- zayıf bağımlılık
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
           _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {         
                        
              var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
             
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Product product) // Controller2in bildiği yer burası. bunun için eklemek istediğimiz şeyi buraya koyarız.
        {
            var result = _productService.Add(product); // gönderdiğimiz şeyi de oraya koy diyoruz.
                                                       // Ayrıca, burası bi IResult. Yani burada data yok.
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
           
    }
}
