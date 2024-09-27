using FondosXYZ;
using FondosXYZ.Models;
using FondoXYZ.Mdoels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FondoXyz.Data{
    public class dbContext : IdentityDbContext<User>{
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
        }
        
    //Add the models 
    public DbSet<Sede> Sedes { get; set; }
    public DbSet<Apartamento> Apartamentos { get; set; }
    public DbSet<Tarifa> Tarifas { get; set; }
    public DbSet<User> Users {get; set;}
    }

}