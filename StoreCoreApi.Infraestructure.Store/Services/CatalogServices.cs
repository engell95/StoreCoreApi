using System.Collections.Generic;
using StoreCoreApi.Db.Models.Store.Models;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;

namespace StoreCoreApi.Infraestructure.Store
{
    public interface ICatalogServices
    {
        List<Product> GetListProduct();
        List<StoreCoreApi.Db.Models.Store.Models.Store> GetListStore();
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
            try {
                List<Product> products = _context.Products.ToList();
                return products;
            }
            catch(Exception ex){
                _logger.LogError("Error with GetListProduct",ex);  
                // Set the status code and response message
                var errorMessage = "Internal Server Error: " + ex.Message;
                var httpContext = new DefaultHttpContext();
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.WriteAsync(errorMessage);

                // Return an empty list
                return new List<Product>();
            }
        }
        public List<StoreCoreApi.Db.Models.Store.Models.Store> GetListStore(){
            try {
                // throw new Exception("test");
                List<StoreCoreApi.Db.Models.Store.Models.Store> products = _context.Stores.ToList();
                return products;
            }
            catch(Exception ex){
                _logger.LogError("Error with GetListProduct",ex);  
                // Set the status code and response message
                var errorMessage = "Internal Server Error: " + ex.Message;
                var httpContext = new DefaultHttpContext();
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                httpContext.Response.WriteAsync(errorMessage);

                // Return an empty list
                return new List<StoreCoreApi.Db.Models.Store.Models.Store>();
            }
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