using Business.Features;
using DataBase.Context;
using DataBase.Models;
using DataBase.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Logic.DataManagement;
using Logic.Database;
using Logic.Functions;
using Logic.Graph;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IRepository<Product>, ProductRepository>();
            services.AddScoped<IFavoriteProducts, FavoriteProducts>();
            
            services.AddTransient<RecordRepository>();
            services.AddTransient<IPopularProducts, PopularProducts>();
            services.AddTransient<IDataModel, DataModel>();
            services.AddTransient<IReader, Reader>();
            services.AddTransient<IUpdater, Updater>();
            services.AddTransient<ICheapest, Cheapest>();
            services.AddTransient<ITextProcessing, TextProcessing>();
            services.AddTransient<IConverter, Converter>();
            services.AddTransient<ICheapestStore, CheapestStore>();
            services.AddTransient<IGraphOperations, GraphOperations>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{action}/{id?}");
            });
        }
    }
}
