using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using train_odata_controller_sever.Data;
using train_odata_controller_sever.Models;

namespace train_odata_controller_sever
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Train Signal API",
                    Version = "v1",
                    Description = "API for Train Signal IR Server",
                    Contact = new OpenApiContact
                    {
                        Name = "Quach Khang",
                        Email = "phuckhang1088@gmail.com",
                        Url = new Uri("https://yourwebsite.com")
                    }
                });
            });

            // OData setup
            builder.Services.AddControllers()
                .AddOData(options =>
                {
                    var odataBuilder = new ODataConventionModelBuilder();
                    odataBuilder.EntitySet<Product>("Products");
                    odataBuilder.EntitySet<SubCategory>("SubCategories");
                    odataBuilder.EntitySet<Category>("Categories");
                    odataBuilder.EntitySet<Inventory>("Inventories");

                    options.Select().Filter().Expand().OrderBy().Count().SetMaxTop(100)
                           .AddRouteComponents("odata", odataBuilder.GetEdmModel());
                });


            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Train OData Controller API v1");
                c.RoutePrefix = "swagger"; // Swagger UI available at: https://localhost:5001/swagger
            });

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
