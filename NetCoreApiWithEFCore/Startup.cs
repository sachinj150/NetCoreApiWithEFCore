using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module1.Data;
using Module1.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Module1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddXmlSerializerFormatters();
            services.AddApiVersioning(o => o.ApiVersionReader = new MediaTypeApiVersionReader());
            services.AddDbContext<ProductsDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("ProductDBContext")));
            services.AddScoped<IProduct, ProductRepository>();
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new Info() {Title = "NetCoreApiWithEFCore", Version = "v1"}));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ProductsDbContext productsDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "Api for Net Core with EF Core"));
            app.UseMvc();
            //productsDbContext.Database.EnsureCreated();
        }
    }
}
