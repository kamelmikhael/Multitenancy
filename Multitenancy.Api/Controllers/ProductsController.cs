using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multitenancy.Api.Dtos;
using Multitenancy.Core.Interfaces;

namespace Multitenancy.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var productList = await _service.GetAllAsync();
        return Ok(productList);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        var productDetails = await _service.GetByIdAsync(id);
        return Ok(productDetails);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateProductRequest request)
    {
        return Ok(await _service.CreateAsync(request.Name, request.Description, request.Rate));
    }
}
