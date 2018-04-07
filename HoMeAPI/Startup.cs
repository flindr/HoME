using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoMeAPI.Controllers;
using HoMeAPI.Entities;
using HoMeAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HoMeAPI
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
            services.AddMvc();

            var connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Database=Measurements;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<MeasurementsContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IMeasurementsRepository, MeasurementsRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AutoMapper.Mapper.Initialize(cfg => 
                cfg.CreateMap<MeasurementDto, Measurement>()
            );

            app.UseMvc();
        }
    }
}
