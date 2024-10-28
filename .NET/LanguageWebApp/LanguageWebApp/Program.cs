using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace LanguageWebApp
{
    public class Program
    {
        private static readonly string[] configureOptions = new[] { "en", "es" };

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews().AddViewLocalization().AddDataAnnotationsLocalization();
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");



            builder.Services.Configure<RequestLocalizationOptions>(options =>

            {

                var supportedCultures = new[] { "en", "es", "hi" };



                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");

                options.SupportedCultures = supportedCultures.Select(culture => new System.Globalization.CultureInfo(culture)).ToList();

                options.SupportedUICultures = supportedCultures.Select(culture => new System.Globalization.CultureInfo(culture)).ToList();



                // Add a culture provider to support the "culture" query string

                options.RequestCultureProviders.Insert(0, new Microsoft.AspNetCore.Localization.QueryStringRequestCultureProvider());

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value;
            app.UseRequestLocalization(localizationOptions);
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
