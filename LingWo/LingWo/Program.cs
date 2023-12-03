using LingWo.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LingWo.DataAccess.Repository.Abstract;
using LingWo.DataAccess.Repository;
using LingWo.Models;
using LingWo.DataAccess.Initializer;
using LingWo.Services.Abstract;
using LingWo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVideoRepository, VideoRepository>();

builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVideoService, VideoService>();

builder.Services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDbInitializer, DbInitializer>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddDefaultTokenProviders().AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();
var scope = app.Services.CreateScope();
var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

dbInitializer.Initialize();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
