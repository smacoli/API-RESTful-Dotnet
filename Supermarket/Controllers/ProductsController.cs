﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Resources;
using Supermarket.Domain.Models;
using Supermarket.Domain.Services;

namespace Supermarket.Controllers
{
    [Route("/api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

       public ProductsController(IProductService productService, IMapper mapper ) 
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<ProductResource>), 200)]
        public async Task<IEnumerable<ProductResource>> ListAsync()
        {
            var products = await _productService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>( products );
            return resources;
        }
    }
}
