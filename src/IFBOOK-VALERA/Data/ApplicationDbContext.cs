using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IFBOOK_VALERA.Models;

namespace IFBOOK_VALERA.Data
{
#pragma warning disable CS1701 // Assuming assembly reference matches identity
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Publicacao> Publicacoes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<Comentario>()
                .HasOne(c => c.publicacao)
                .WithMany(p => p.Comentarios)
                .HasForeignKey(c => c.PublicacaoId)
                .HasPrincipalKey(p => p.Id);

            builder.Entity<Comentario>()

                .HasOne(c => c.Usuario)
                .WithMany(u => u.Comentarios)
                .HasForeignKey(c => c.UserId)
                .HasPrincipalKey(u => u.Id);

            builder.Entity<Publicacao>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Publicacoes)
                .HasForeignKey(p => p.UserId)
                .HasPrincipalKey(u => u.Id);

        }
    }
#pragma warning restore CS1701 // Assuming assembly reference matches identity
}
