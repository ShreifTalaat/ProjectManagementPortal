<<<<<<< HEAD
<<<<<<< HEAD

namespace DAL
=======
using BLL.Interfaces;
using BLL.Services;
using DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProjectManagementPortal
>>>>>>> cea2eebcbd29fd412e849c956bddabdc077dcfe0
=======

namespace BLL
>>>>>>> 09ffe02fb864ec030feecec2c70857408510194f
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 09ffe02fb864ec030feecec2c70857408510194f

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
<<<<<<< HEAD
=======
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<ITask, TaskService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            // Retrieve the configuration
            var configuration = builder.Configuration;

            // Configure the DbContext with the connection string
            builder.Services.AddDbContext<ProjectManagementDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ProjectManagementDBConnection"));

            });
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost3000",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
>>>>>>> cea2eebcbd29fd412e849c956bddabdc077dcfe0
=======
>>>>>>> 09ffe02fb864ec030feecec2c70857408510194f

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> 09ffe02fb864ec030feecec2c70857408510194f

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
<<<<<<< HEAD
}
=======
            app.UseCors("AllowLocalhost3000");

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
>>>>>>> cea2eebcbd29fd412e849c956bddabdc077dcfe0
=======
}
>>>>>>> 09ffe02fb864ec030feecec2c70857408510194f
