// https://www.toptal.com/asp-dot-net/asp-net-web-api-tutorial - UnitOfWork
// https://stackoverflow.com/questions/43058994/how-to-add-src-folder-at-solution-root/63337345#63337345 - add src folder
using Microsoft.EntityFrameworkCore;
using OMSServiceMaxi.DAL.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connString = builder.Configuration.GetConnectionString("OMSDatabase");
builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connString));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();