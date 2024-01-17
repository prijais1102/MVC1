namespace MVCDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("hello1 hello2 ");
                await next();
            });
            app.Map("/hello", MapBranchOne);
            static void MapBranchOne(IApplicationBuilder app)
            {
                app.Use(async (context,next) => {
                    await context.Response.WriteAsync("hello");
                    await next();
                });
            }
            app.Map("/end", MapBranchTwo);
            static void MapBranchTwo(IApplicationBuilder app)
            {
                app.Run(async context =>
                {
                    await context.Response.WriteAsync("Terminated");
                });

            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=First}/{action=Index1}/{id?}");

            app.Run();
        }
    }
}
