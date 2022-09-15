using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;
using MovieStoreWebApi.Interfaces;
using MovieStoreWebApi.Models.ModelsDirector.Request;
using MovieStoreWebApi.ModelsCustomer.Request;
using MovieStoreWebApi.ModelsRole.Request;
using MovieStoreWebApi.MovieModels.Request;
using MovieStoreWebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStoreWebApi
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

            services.AddControllers();

            services.AddDbContext<MovieStoreDbContext>(opt =>
            {
                opt.UseSqlServer("Server=DESKTOP-7IFFEOA\\SQLEXPRESS;Database=MovieDb;Trusted_Connection=True");
            });
            services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            services.AddSingleton<IValidator<AddRequestVM>, AddRequestVMValidator>();
            services.AddSingleton<IValidator<DirectorRequestVM>, DirectorRequestVMValidator>();
            services.AddSingleton<IValidator<CustomerRequestVm>, CustomerRequestVmValidator>();
            services.AddSingleton<IValidator<RoleRequestVM>, RoleRequestVMValidator>();
            services.AddScoped<IGenericRepository<Movie>, GenericRepository<Movie>>();
            services.AddScoped<IGenericRepository<Customer>, GenericRepository<Customer>>();
            services.AddScoped<IGenericRepository<Director>, GenericRepository<Director>>();
            services.AddScoped<IGenericRepository<Favorite>, GenericRepository<Favorite>>();
            services.AddScoped<IGenericRepository<MovieDirector>, GenericRepository<MovieDirector>>();
            services.AddScoped<IGenericRepository<MovieRole>, GenericRepository<MovieRole>>();
            services.AddScoped<IGenericRepository<Purchase>, GenericRepository<Purchase>>();
            services.AddScoped<IGenericRepository<Role>, GenericRepository<Role>>();
            


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieStoreWebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieStoreWebApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
