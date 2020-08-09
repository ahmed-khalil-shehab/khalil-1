using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repository)
        {
            _repo = repository;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductes()
        {
            var prod = await _repo.GetAllProductes();
            return Ok(prod);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var prod = await _repo.GetProductByIdAsync(id);
            return prod;

        }
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductsPrand()
        {
            return Ok(await _repo.GetProductsBrandsAsync());

        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
    }
}