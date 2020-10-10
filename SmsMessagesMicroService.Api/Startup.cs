using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SmsMessagesMicroService.Api.DependencyInjection;
using SmsMessagesMicroService.MessageSender;
using SmsMessagesMicroService.Repository;

namespace SmsMessagesMicroService.Api
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
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Sms Messages API", Version = "v1" });
                s.DescribeAllParametersInCamelCase();
            });

            Cqrs.RegisterDependencies(services);
            Database.RegisterDependencies(services);
            Services.RegisterDependencies(services);

            var connection = Configuration["DefaultDatabaseConnection"];
            services.AddDbContext<MessagesDbContext>(options => options.UseSqlServer(connection));

            services.Configure<RabbitMqConnection>(Configuration.GetSection("RabbitMq"));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsApiPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sms Messages API"); });
            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
