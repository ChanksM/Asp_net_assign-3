using Microsoft.EntityFrameworkCore;
using AspNetAssign.Models;
 
 
var builder = WebApplication.CreateBuilder(args);
 
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
 
builder.Services.AddDbContext<StudentsContext>(options => options.UseSqlite(connection));
 
builder.Services.AddControllersWithViews();
 
var app = builder.Build();
 
app.MapDefaultControllerRoute();
 
app.Run();