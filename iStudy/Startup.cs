using AutoMapper;
using iStudy.Business.Mapper;
using iStudy.Business.Services;
using iStudy.Core.Repository;
using iStudy.Infrastructure.Data;
using iStudy.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iStudy
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "iStudy", Version = "v1" });
            });
            ConfigureAppServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "iStudy v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public static void ConfigureAppServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<AppDataContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IStudentService,StudentService>();
            services.AddScoped<ITeachersService, TeachersService>();
            services.AddScoped<ICitiesService, CitiesService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IStudentSubjectsService, StudentSubjectsService>();
            services.AddScoped<ITeacherSubjectsService, TeacherSubjectsService>();
            services.AddScoped<ISubjectService,SubjectService>();
            services.AddAutoMapper(typeof(IEMapper));

        }
    }
}
