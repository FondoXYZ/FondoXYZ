using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FondoXyz.Data{
    public class dbContext : IdentityDbContext{
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {

        }
    }
    //Add the models 
    
}