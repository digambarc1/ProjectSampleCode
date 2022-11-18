using CarDekho;
//using CarDekho.Handlers;
using CarDekho.Models;
using CarDekho.Repository;
using CarDekho.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CarDekhoDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UserContext")));
builder.Services.AddScoped<IBuyerRepo, BuyerService>();
builder.Services.AddScoped<ISellerRepo, SellerService>();
builder.Services.AddScoped<IProviderRepo, ProviderService>();
builder.Services.AddScoped<INewCarRepo, NewCarService>();
builder.Services.AddScoped<IUsedCarRepo, UsedCarService>();
builder.Services.AddScoped<IAdminRepo, AdminService>();

//builder.Services.AddSwaggerGen(o =>
//{
//    o.AddSecurityDefinition("basic", new OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Scheme = "basic",
//        Type = SecuritySchemeType.Http,
//        Description = "Basic Authentication using http security scheme"
//    });

//    o.AddSecurityRequirement(new OpenApiSecurityRequirement {
//        {
//            new OpenApiSecurityScheme {
//                Reference = new OpenApiReference {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "basic"
//                }
//            },
//            new string[] { }
//        },
//    });
//});

//builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, CAuthenticationHandler>("BasicAuthentication", null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



//   cors code




app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

app.UseHttpsRedirection();

//app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
