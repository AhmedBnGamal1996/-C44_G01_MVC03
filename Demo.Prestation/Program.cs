using Demo.BusinessLogic.Mappings;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Data.Context;
using Demo.DataAccess.Data.Repository;
using Demo.DataAccess.Data.Repository.Classes;
using Demo.DataAccess.Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
 

namespace Demo.Prestation
{
    public class Program
    {
        public static void Main(string[] args)
        {



            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            #region DI Container 




            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });



            // builder.Services.AddScoped<ApplicationDbContext>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            { 
            // options.UseSqlServer("ConnectionString")

            // options.UseSqlServer(builder.Configuration["ConnectionString:DefaultConnectiosString"])
            // options.UseSqlServer(builder.Configuration.GetSection("ConnectionString")["DefaultConnectionString"]); 

            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
                options.UseLazyLoadingProxies();


            });

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            

            builder.Services.AddScoped<IDepartmentService, DepartmentService>();


            builder.Services.AddScoped<IEmployeeRepository , EmployeeRepository>();

            builder.Services.AddScoped<IEmployeeService , EmployeeService>();


            // builder.Services.AddAutoMapper(cfg => { } , typeof(MappingProfile).Assembly);


            builder.Services.AddAutoMapper(mapping => mapping.AddProfile(new MappingProfile()));



            #endregion




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();  // Midelware that make sure all request secured in the deploment 

            }





            app.UseHttpsRedirection();
            app.UseStaticFiles();



            app.UseStaticFiles();

            app.UseRouting();






            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");



            app.Run();





            /* 
             * 
            Department Module 

            -- Model 
            ==>  Name , Code , Descriptian [ Properties Department ] 

            ==>  ID , CreatedBy , CreatedOn , ModifiedBy , ModifiedOn , IsDeleted { {Soft Delete }   All Models } {Parent Class } 







             * */




        }
    }
}