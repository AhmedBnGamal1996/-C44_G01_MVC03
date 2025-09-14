using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


#region DI Container 

builder.Services.AddControllersWithViews();

// builder.Services.AddScoped<ApplicationDbContext>();

builder.Services.AddDbContext<Demo.DataAccess.Data.Context.ApplicationDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") 
    });





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