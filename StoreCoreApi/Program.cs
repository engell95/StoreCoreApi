using Microsoft.EntityFrameworkCore;
using StoreCoreApi.Infraestructure.Store;
using StoreCoreApi.Db.Models.Store.Models;
using NLog;
using NLog.Web;
using Microsoft.AspNetCore.Diagnostics;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
    {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    //dbsmodels store services
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<StoreTestContext>(x => x.UseSqlServer(connectionString));
    
    //services store
    builder.Services.AddCatalogServices();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    else{
       app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                context.Response.StatusCode = 500; // Internal Server Error
                context.Response.ContentType = "application/json";

                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (errorFeature != null)
                {
                    var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                    logger.Error(errorFeature.Error, "Unhandled error occurred");

                    await context.Response.WriteAsJsonAsync(new { error = "Internal Server Error" });
                }
            });
        });
    }

    // Configurar middleware para redirección
    app.Use((context, next) =>
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
            return Task.CompletedTask;
        }

        return next();
    });

    app.UseHttpsRedirection();
    app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}