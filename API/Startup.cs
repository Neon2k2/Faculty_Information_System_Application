using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Faculty_Information_System_Application
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

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                 {
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                 });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Faculty_Information_System_Application", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
            services.AddDbContext<FacultyInformationSystemContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IAdministratorRepository, AdministratorRepository>();
            services.AddScoped<IAdministratorSearchRepository, AdminstratorSearchRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseSubjectRepository, CourseSubjectRepository>();
            services.AddScoped<ICourseTaughtRepository, CourseTaughtRepository>();
            services.AddScoped<IDegreeRepository, DegreeRepository>();
            services.AddScoped<IDepartment, DepartmentRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IFacultySearchRepository, FacultySearchRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IGrantRepository, GrantRepository>();
            services.AddScoped<IPublicationRepository, PublicationRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWorkHistoryRepository, WorkHistoryRepository>();
            services.AddScoped<IRoleLookupRepository, RoleLookupRepository>();
            services.AddScoped<IJWTManagerRepository, JWTManagerRepository>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };
            });

            services.AddCors();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Faculty_Information_System_Application v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
