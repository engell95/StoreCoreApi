using System.Collections.Generic;
using StoreCoreApi.Db.Models.Store.Models;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore;

namespace StoreCoreApi.Infraestructure.Store
{
    public interface ICatalogServices
    {
        List<Product> GetListProduct();
    }

    public class CatalogServices: ICatalogServices
    {
        private readonly StoreTestContext _context;
        private readonly ILogger<ICatalogServices> _logger;

        public CatalogServices(StoreTestContext context, ILogger<ICatalogServices> logger){
            _context = context;
            _logger = logger;
        }

        public List<Product> GetListProduct(){
            List<Product> Product = null;
            try {
                throw new Exception("test");
                Product = _context.Products.ToList();
            }
            catch(Exception ex){
                _logger.LogError("Error with GetListProduct",ex);  
            }
            return Product;
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