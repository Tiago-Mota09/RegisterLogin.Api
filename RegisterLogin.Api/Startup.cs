using Angis.CTe.API.Filters;
using RegisterLogin.API.ServicesCollections;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RegisterLogin.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //This method gets called by the runtime.Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region :: Services ::
            services.AddFluentValidationServices();
            services.SwaggerServices();
            services.DapperServices();
            services.BusinessServices();
            services.RepositoryServices();
            #endregion

            #region :: FluentValidation ::
            #endregion

            #region :: Automapper ::
            #endregion

            #region :: Swagger ::
            #endregion

            #region :: Dapper :: 
            #endregion

            #region :: Business ::
            #endregion

            services.AddMvc();
            services.AddControllers();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(conf =>
            {
                conf.SwaggerEndpoint("/swagger/v1/swagger.json", "RegisterLogin API");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseHttpsRedirection();
            //app.UserStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller}/{action}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}
