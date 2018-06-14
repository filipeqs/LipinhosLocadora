using Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Repository;
using Repository.Entities;
using Repository.Services;

namespace API
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
            services.AddDbContext<AppDbContext>( // replace "DbContext" with the class name of your DbContext
                options => options.UseMySQL("Server=localhost;Port=3306;Database=LipinhosLocadora;User=root;Password=12345;SslMode=none", // replace with Connection String
                                            b => b.MigrationsAssembly("API")));

            services.Configure<FormOptions>(options => options.BufferBody = true);

            services.AddScoped<User>();
            services.AddScoped<Movie>();
            services.AddScoped<MovieRepository>();
            services.AddScoped<UserRepository>();
            services.AddScoped<DomainDispatcher>();        

            services.AddMvc()
                    .AddJsonOptions(opt => opt.SerializerSettings.ContractResolver
                                         = new DefaultContractResolver());

            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:49304")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            );

            app.UseMvc();
        }
    }
}
