using Microsoft.AspNetCore.Mvc;
using StoreCoreApi.Infraestructure.Store;
using StoreCoreApi.Db.Models.Store.Models;

namespace StoreCoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogController : ControllerBase{
    private readonly ICatalogServices _catalogservices; 

    public CatalogController(ICatalogServices catalogservices)
    {
        _catalogservices = catalogservices;
    }
    
    [HttpGet("Store")]
    public ActionResult<List<Store>> GetListStore()
    {
        return _catalogservices.GetListStore();
    }

    [HttpGet("Product")]
    public ActionResult<List<Product>> GetListProduct()
    {
        return _catalogservices.GetListProduct();
    }



}