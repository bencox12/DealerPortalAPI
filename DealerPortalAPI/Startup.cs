using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DealerPortalAPI.Models;

namespace DealerPortalAPI
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("*");
                    });
            });

            services.AddControllers();

            services.AddDbContext<DealerPortalContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DealerPortalDatabase")));
            services.AddDbContext<AllInNewContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AllInDatabase")));
            services.AddDbContext<LabelsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PieceRateDatabase")));
            services.AddDbContext<docimagingContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DocImagingDatabase")));
            services.AddDbContext<ReportMasterContext>(options => options.UseSqlServer(Configuration.GetConnectionString("RepMasterDatabase")));
            services.AddDbContext<SysproCompanyAContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SysproDatabase")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
