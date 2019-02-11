using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;
using TaiwanMuscle.Common;
using TaiwanMuscle.Models;

namespace TaiwanMuscle
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
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

           // services.AddDbContextPool<ProteinsContext>( // replace "YourDbContext" with the class name of your DbContext
           //    options => options.UseMySql("server=proteins.cdys9koffynq.us-east-1.rds.amazonaws.com;port=3306;database=Proteins;uid=protein;password=hilosystem;", // replace with your Connection String
           //        mySqlOptions =>
           //        {
           //            mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
           //         }
           //));
            services.AddDbContextPool<ProteinsContext>(options => options.UseMySql("server=proteins.cdys9koffynq.us-east-1.rds.amazonaws.com;port=3306;database=Proteins;uid=protein;password=hilosystem;"));

            #region  添加SwaggerUI

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "API接口文档",
                    Version = "v1",
                    Description = "RESTful API for ManagerApi",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "", Email = "", Url = "" }
                });
                options.IgnoreObsoleteActions();
                options.DocInclusionPredicate((docName, description) => true);
                options.DescribeAllEnumsAsStrings();
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ProteinsContext proteinsContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            // 建立資料庫            
            proteinsContext.Database.EnsureCreated();

            app.UseHttpsRedirection();
            app.UseMvc();

            #region 使用SwaggerUI

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Dinner API V1");
            });

            #endregion
        }
    }
}
