using Claswork_ASP_APP.Serves;
using Copy_Classwork_APS_APP.DAL;
using Copy_Classwork_APS_APP.DAL.Interfaces;
using Copy_Classwork_APS_APP.DAL.Repositiores;
using Microsoft.EntityFrameworkCore;

namespace Claswork_ASP_APP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ProfileInterface,ProfileRepository>();
			builder.Services.AddScoped<IProfileServis, ProfileServis>();
			builder.Services.AddScoped<IBookShopRepository, BookShopRepository>();
			builder.Services.AddScoped<IBookShopServes, BookShopServes>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
