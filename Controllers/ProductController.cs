using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Todo.Dtos;
using Todo.Interface;
using Todo.Mappers;
using Todo.Models;

namespace Todo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // Controller sınıfları iş mantığını yönetir. gelen requestlere karşılık verir.
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly INotificationService _notificationService;
        public ProductController(IProductRepository productRepository, INotificationService notificationService)
        {
            _productRepository = productRepository;
            _notificationService = notificationService;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var product = await _productRepository.GetProducts();
            return Ok(product);      
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto){
            await _productRepository.AddProduct(productDto.MapToProduct()); 
            BackgroundJob.Enqueue(() => _notificationService.SendNotification("Product added"));
            return Ok("Product added successfully");    
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id){
            var product = await _productRepository.GetProductById(id);
            if(product == null){
                return NotFound("Product not found");
            }
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute ]int id){
            var product = await _productRepository.DeleteProduct(id);
            if(product == null){
                return NotFound("Product not found");
            }
            BackgroundJob.Schedule(() => _notificationService.SendNotification("Product deleted"), TimeSpan.FromMinutes(1));
            return Ok("Product deleted successfully");     
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProdcut([FromRoute] int id, [FromBody] ProductDto productDto){
            var product = await _productRepository.UpdateProduct(id, productDto.MapToProduct());
            if(product == null){
                return NotFound("Product not found");
            }
            BackgroundJob.Schedule(() => _notificationService.SendNotification("Product updated"), TimeSpan.FromMinutes(1));
            return Ok("Product updated successfully");       
        }
    }
}