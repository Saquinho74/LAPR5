using DDDNetCore.Domain.Categories;
using DDDNetCore.Domain.Credential;
using DDDNetCore.Domain.Families;
using DDDNetCore.Domain.Operation;
using DDDNetCore.Domain.OperationType;
using DDDNetCore.Domain.Patient;
using DDDNetCore.Domain.Products;
using DDDNetCore.Domain.Shared;
using DDDNetCore.Domain.SurgeryRoom;
using DDDNetCore.Domain.Staffs;
using DDDNetCore.Infraestructure;
using DDDNetCore.Infraestructure.Categories;
using DDDNetCore.Infraestructure.Credential;
using DDDNetCore.Infraestructure.Families;
using DDDNetCore.Infraestructure.Operation;
using DDDNetCore.Infraestructure.OperationTypes;
using DDDNetCore.Infraestructure.Patient;
using DDDNetCore.Infraestructure.Products;
using DDDNetCore.Infraestructure.Shared;
using DDDNetCore.Infraestructure.SurgeryRoom;
using DDDNetCore.Infraestructure.Staffs;
using DDDNetCore.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OperationRepository = DDDNetCore.Infraestructure.Operation.OperationRepository;

namespace DDDNetCore
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
            services.AddDbContext<DddSample1DbContext>(opt =>
                opt.UseInMemoryDatabase("DDDSample1DB")
                .ReplaceService<IValueConverterSelector, StronglyEntityIdValueConverterSelector>());

            ConfigureMyServices(services);
            
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // Enable middleware to serve generated Swagger as a JSON endpoint
                app.UseSwagger();

                // Enable middleware to serve Swagger-UI (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = string.Empty; // Set Swagger UI at the root of the application
                });
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureMyServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddTransient<IUnitOfWork,UnitOfWork>();
            
            services.AddTransient<OperationTypeMapper>();

            
            services.AddTransient<IOperationTypeRepository,OperationTypeRepository>();
            services.AddTransient<OperationTypeService>();

            services.AddTransient<OperationService>();
            services.AddTransient<IOperationRepository,OperationRepository>();

            services.AddTransient<StaffService>();
            services.AddTransient<IStaffRepository, StaffRepository>();
            
            services.AddTransient<CredentialService>();
            services.AddTransient<ICredentialRepository,CredentialRepository>();

            services.AddTransient<SurgeryRoomService>();
            services.AddTransient<ISurgeryRoomRepository, SurgeryRoomRepository>();

            services.AddSwaggerGen();

            services.AddTransient<PatientService>();
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<PatientMapper>();


        }
    }
}
