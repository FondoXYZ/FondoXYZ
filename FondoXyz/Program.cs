using FondoXyz.Data;
using FondoXYZ.Mdoels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add the services of sqlServer
builder.Services.AddDbContext<dbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Add the services of identity
builder.Services.AddIdentity<User , IdentityRole>( //Yo editare el modelo user, por eso es solo user
    options => {
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 4; //El documento nos dice que la clave debe tener 4 digitos
    }
)
.AddEntityFrameworkStores<dbContext>()
.AddDefaultTokenProviders(); // we save the token in the context

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Sedes}/{action=Index}/{id?}");

app.Run();
