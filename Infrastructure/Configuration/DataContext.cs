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
        public DbSet<Categoria> Categorias {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder )
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole => 
                {
                
                    modelBuilder.Entity<ProdutosCategorias>()
                    .HasKey(PC => new {PC.ProdutoId, PC.CategoriaId});

                    modelBuilder.Entity<ProdutosCategorias>()
                    .HasOne(pc => pc.Produto)
                    .WithMany(pc => pc.ProdutosCategorias)
                    .HasForeignKey(pc => pc.ProdutoId);
                    
                    modelBuilder.Entity<ProdutosCategorias>()
                    .HasOne(pc => pc.Categoria)
                    .WithMany(pc => pc.ProdutosCategorias)
                    .HasForeignKey(pc => pc.CategoriaId);

                    // modelBuilder.Entity<Produto>()
                    // .HasMany(e => e.RedesSociais)
                    // .WithOne(rs => rs.Evento)
                    // .OnDelete(DeleteBehavior.Cascade);

                    // modelBuilder.Entity<Palestrante>()
                    // .HasMany(e => e.RedesSociais)
                    // .WithOne(rs => rs.Palestrante)
                    // .OnDelete(DeleteBehavior.Cascade);

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