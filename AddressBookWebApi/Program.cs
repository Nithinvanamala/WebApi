using AddressBook.Repository.EfCore;
using AddressBookWebApi;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var container = new Container();
container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

builder.Services.AddCors(path =>
{
    path.AddPolicy(MyAllowSpecificOrigins,
    builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500")
     .AllowAnyHeader()
     .AllowAnyMethod();
    });
});



builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});



IConfiguration configuration = builder.Configuration; 
builder.Services.Addauth(configuration);

builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore()
        .AddControllerActivation(Lifestyle.Scoped);
        
        options.AddLogging();
});
container.RegisterPackages(new[] { typeof(RegisterServices).Assembly });




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();



app.MapControllers();

app.Run();
