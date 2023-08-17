using System.Collections.Generic;
using StoreCoreApi.Db.Models.Store.Models;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace StoreCoreApi.Infraestructure.Store
{
    public interface ICatalogServices
    {
        List<Product> GetListProduct();
    }

    public class CatalogServices: ICatalogServices
    {
        private readonly StoreTestContext _context;
        private readonly ILogger<CatalogServices> _logger;

        public CatalogServices(StoreTestContext context){
            _context = context;
        }

        public List<Product> GetListProduct(){
            var users = _context.Products.ToList();
            return users;
        }

    }

    public static class CatalogServicesExtensions
    {
        public static IServiceCollection AddCatalogServices(this IServiceCollection Services){
            Services.AddTransient<ICatalogServices, CatalogServices>();
            return Services;
        }
    }
}