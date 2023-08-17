using Microsoft.AspNetCore.Mvc;
using StoreCoreApi.Infraestructure.Store;
using StoreCoreApi.Db.Models.Store.Models;

namespace StoreCoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoreController : ControllerBase{
    private readonly ICatalogServices _catalogservices; 

    public StoreController(ICatalogServices catalogservices)
    {
        _catalogservices = catalogservices;
    }

    [HttpGet("Catalog/Product")]
    public ActionResult<List<Product>> GetListProduct()
    {
        return _catalogservices.GetListProduct();
    }

}