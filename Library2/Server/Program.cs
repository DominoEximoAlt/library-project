using Library2.Server.Context;
using Library2.Server.Services;
using Library2.Server.Services.Implementation;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); 
builder.Services.AddDbContext<BookContext>(options =>
    {
        options.UseMySQL(builder.Configuration.GetConnectionString("Default"));
    }
);

builder.Services.AddScoped<IBookService, BookService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());


app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();