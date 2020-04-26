using Festival.Security.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Festival.Security.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@" Server=app.fit.ba, 1431;
            
                                            Database=Festival_Identity;

                                            Trusted_Connection=False;

                                            MultipleActiveResultSets=true;

                                            User ID=identityUser;

                                            Password=f9pctz!");

        }
    }
}
