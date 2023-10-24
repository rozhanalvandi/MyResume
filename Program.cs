using Microsoft.EntityFrameworkCore;
using Resume.Application.Services;
using Resume.Application.Services.Implementation;
using Resume.Application.Services.Interfaces;
using Resume.Domain.RepositoryInterface;
using Resume.Infrastructure.Dbcontext;
using Resume.Infrastructure.Repository;

namespace Resume.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
       
        builder.Services.AddScoped<IEducationRepository, EducationRepository>();
        builder.Services.AddScoped<IExprienceRepository, ExprienceRepository>();
        builder.Services.AddScoped<IMySkillsRepository, MySkillsRepository>();
        builder.Services.AddScoped<IContactRepository, ContactRepository>();

        builder.Services.AddDbContext<ResumeDbContext>();

        builder.Services.AddScoped<IContactService, ContactService>();
        builder.Services.AddScoped<IDashbordService, DashbordService>();
        builder.Services.AddScoped<IEducationService, EducationService>();
        builder.Services.AddScoped<IExprienceService, ExprienceService>();
        builder.Services.AddScoped<IMyskillsService, MySkillService>();





        builder.Services.AddDbContext<ResumeDbContext>(op =>
               op.UseSqlite(builder.Configuration.GetConnectionString("AppDbContext")));

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name : "area",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

