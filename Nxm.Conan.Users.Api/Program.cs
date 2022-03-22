using Nxm.Conan.Users.Infrastructure.Data.DbConfigs;
using Nxm.Conan.Users.Core.Helpers;
using Nxm.Conan.Users.Core.Mapping;
//using Conan_1.Middlewares;

using Nxm.Conan.Users.Core.Repositories;
using Nxm.Conan.Users.Core.Repositories.V1;
using Nxm.Conan.Users.Infrastructure.Repositories;
using Nxm.Conan.Users.Infrastructure.Repositories.V1;

using Nxm.Conan.Users.Core.Services.V1;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
//using Swashbuckle.AspNetCore.Filters;
//using Swashbuckle.Swagger;
//using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    services.AddCors();
    services.AddControllers();

    services.AddSwaggerGen();

    builder.Services.AddSwaggerGen(opt =>
    {
        opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
        opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });

        opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    });
    // configure strongly typed settings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    // configure mogodb connection string
    services.Configure<DatabaseConfigurations>(builder.Configuration.GetSection("DatabaseConfigurations"));

    services.AddSingleton<IDatabaseConfigurations>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<DatabaseConfigurations>>().Value);

    // contract to entity (vise versa) mapper configuration
    services.AddAutoMapper(typeof(AutoMapperProfile));

    // configure DI for application repositories
    services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    services.AddTransient<IUserRepository, UserRepository>();
    //services.AddTransient<IOfferRepository, OfferRepository>();
    //services.AddTransient<IEntrepriseRepository, EntrepriseRepository>();
    //services.AddTransient<IInterviewRepository, InterviewRepository>();
    //services.AddTransient<ICvRepository, CvRepository>();
    //services.AddTransient<ICommentRepository, CommentRepository>();




    // configure DI for application services

    services.AddScoped<IUserService, UserService>();
    //services.AddScoped<IAccountService, AccountService>();
    //services.AddScoped<IOfferService, OfferService>();
    //services.AddScoped<IEntrepriseService, EntrepriseService>();
    //services.AddScoped<IInterviewService, InterviewService>();
    //services.AddScoped<ICvService, CvService>();
    //services.AddScoped<ICommentService, CommentService>();





}

var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    //// global error handler
    //app.UseMiddleware<ErrorHandlerMiddleware>();

    //// custom jwt auth middleware
    //app.UseMiddleware<JwtMiddleware>();

    app.UseSwagger();

    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

app.Run();