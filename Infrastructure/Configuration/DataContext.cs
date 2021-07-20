using Microsoft.EntityFrameworkCore;
using Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Domain.Identity;

namespace ProAgil.Repository
{
    public class DataContext : IdentityDbContext<User, Role, int,
                                    IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
    
        public DbSet<Produto> Produtos {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole => 
                {
                    userRole.HasKey(ur => new {ur.UserId, ur.RoleId});

                    userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();
                    
                    userRole.HasOne(ur => ur.User)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
                }
            );
            
        }
    
    }
}