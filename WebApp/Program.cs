using System.IdentityModel.Tokens.Jwt;
using System.Text;
using App.Contracts.DAL;
using App.DAL.EF;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ??
                       throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// Database End

// Dependency Injection
builder.Services
    .AddScoped<IAppUnitOfWork, AppUnitOfWork>();
// Dependency Injection End

// Identity
builder.Services
    .AddIdentity<AppUser, AppRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddDefaultUI()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// JWT Auth with cookie support
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
builder.Services
    .AddAuthentication()
    .AddCookie(options => { options.SlidingExpiration = true; })
    .AddJwtBearer(cfg =>
    {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration.GetValue<string>("JWT:issuer"),
            ValidAudience = builder.Configuration.GetValue<string>("JWT:audience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                (builder.Configuration.GetValue<string>("JWT:key")!)),
            ClockSkew = TimeSpan.Zero // remove delay of token when expire
        };
    });
// JWT Auth with cookie support End
// Identity End

// MVC
builder.Services.AddControllersWithViews();
// MVC End

//==============================================
var app = builder.Build();
//==============================================

MigrateData(app);
SeedUsersAndRoles(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Configure the HTTP request pipeline End

// Default Config
app.UseHttpsRedirection()
   .UseStaticFiles()
   .UseRouting()
   .UseAuthorization();
// Default Config End

// Controller Routes
app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Controller Routes End

app.MapRazorPages();

app.Run();

static void MigrateData(WebApplication app)
{
    using var serviceScope =
        ((IApplicationBuilder)app).ApplicationServices
        .GetRequiredService<IServiceScopeFactory>()
        .CreateScope();

    using var context =
        serviceScope.ServiceProvider
            .GetRequiredService<AppDbContext>();
    
    context.Database.Migrate();
}

static void SeedUsersAndRoles(WebApplication app)
{
    using var serviceScope =
        ((IApplicationBuilder)app).ApplicationServices
        .GetRequiredService<IServiceScopeFactory>()
        .CreateScope();

    using var context =
        serviceScope.ServiceProvider
            .GetRequiredService<AppDbContext>();
    
    using var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    using var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
    
    var res = roleManager.CreateAsync(new AppRole()
    {
        Name = "Admin"
    }).Result;
    
    if (!res.Succeeded)
    {
        Console.WriteLine(res.ToString());
    }
    
    var user = new AppUser()
    {
        Email = "admin@admin.ee",
        UserName = "admin@admin.ee"
    };
    res = userManager.CreateAsync(user, "Admin.123").Result;
    if (!res.Succeeded)
    {
        Console.WriteLine(res.ToString());
    }
    
    
    res = userManager.AddToRoleAsync(user, "Admin").Result;
    if (!res.Succeeded)
    {
        Console.WriteLine(res.ToString());
    }
}
