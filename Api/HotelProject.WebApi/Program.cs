using HotelProject.DataAccessLayer.Concrete.Database;
using HotelProject.WebApi.Extensions;
using System.Reflection;
using static HotelProject.DataAccessLayer.Concrete.Database.DbContextServiceExt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextServices(builder.Configuration);
builder.Services.AddBusinessServices(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());  


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
