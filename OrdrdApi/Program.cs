global using OrdrdApi.Data;
global using OrdrdApi.Models;
global using Microsoft.EntityFrameworkCore;
using Serilog;
using Infobip.Api.Client;
using Infobip.Api.Client.Api;
using Microsoft.AspNetCore.ResponseCompression;
using OrdrdApi.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using OrdrdApi.Services.UserServ;
using OrdrdApi.Services.RestaurantServ;
using OrdrdApi.Repositories.UserRepo;
using OrdrdApi.Repositories.OrderRepo;
using OrdrdApi.Repositories.RestaurantRepo;
using OrdrdApi.Services.OrderServ;
using OrdrdApi.Services.Infrastructure;
using OrdrdApi.Services.MenuServ;
using OrdrdApi.Repositories.MenuRepo;
using OrdrdApi.Services.HistoryServ;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://landing-page-lilac-pi-43.vercel.app/", "https://admin-panel-rho-sandy.vercel.app/")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("Content-Disposition")
                .AllowCredentials();
        });
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ordrd API Docs", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."

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
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(options =>
    options.MimeTypes = ResponseCompressionDefaults
        .MimeTypes
        .Concat(new[] { "application/octet-stream" })
);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = $"https://{builder.Configuration["Auth0Credentials:Domain"]}/";
    options.Audience = builder.Configuration["Auth0Credentials:Audience"];
});
builder.Services.AddAuthorization();

//Hubs
builder.Services.AddScoped<OrderHub>();


// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IHistoryService, HistoryService>();
builder.Services.AddScoped<IInfrastructureService, InfrastructureService>();


//Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();


var logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
builder.Logging.AddSerilog(logger);


var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<OrderHub>("/orderQueue");
});

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ordrd API v1"));


app.Run();
