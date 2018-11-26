using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DriverManageService.Settings;
using DriverServices.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace DriverServices
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "服务 API"
                });
                //Set the comments path for the swagger json and ui.  
                var filePath = Path.Combine(AppContext.BaseDirectory, "DriverServices.xml");
                options.IncludeXmlComments(filePath);
            });

            var jwt = new JwtSettings();
            Configuration.Bind("JwtSettings", jwt);
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            services.AddSingleton<IRepository>(provider => {
                return new SqlRepository(Configuration.GetConnectionString("SqlDB"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseStaticFiles();

            app.UseSwaggerUI(c =>
            {
                c.InjectStylesheet("/swagger-ui/custom.css");
                c.DocumentTitle = "从业人员服务平台接口文档";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DriverService API V1");
            });

        }
    }
}
