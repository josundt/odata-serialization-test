using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ODataSerializationTest.Data;

namespace ODataSerializationTest
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // OData: Register services
            services.AddOData();

            // OData: WHEN .AddNewtonSoftJson() is used below, the AspNetCore application will use
            // NewtonSoft.Json for serializatoin instead of the new Microsoft default serializer - System.Text.Json).
            // With the NewtonSoft serializer projection ($select) query results are serialized properly.
            // With System.Text.Json it is not.
            // Try toggling line 24 commented/uncommented and see the response difference through the web page.

            services.AddControllers()
                //.AddNewtonsoftJson()
                ;

            services.AddSingleton<IPersonRespository, PersonRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // OData: Requirement for usage in Non-OData-routes
                endpoints.EnableDependencyInjection();

                // OData: Configure supported OData operations
                endpoints
                    .Count()
                    .OrderBy()
                    .Filter()
                    .Select();
            });
        }
    }
}
