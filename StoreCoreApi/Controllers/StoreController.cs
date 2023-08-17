using Microsoft.AspNetCore.Mvc;
using System;
using StoreCoreApi.Infraestructure.Store;
using StoreCoreApi.Db.Models.Store.Models;
using Microsoft.AspNetCore.Authorization;

namespace StoreCoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase{
    private readonly ICatalogServices _catalogservices; 

    public StoreController(ICatalogServices catalogservices)
    {
        _catalogservices = catalogservices;
    }

    [HttpGet("Catalog/UserList")]
    public IActionResult GetListUsers()
    {
        var response = _catalogservices.GetListProduct(); 
        return Ok(response);
    }

}