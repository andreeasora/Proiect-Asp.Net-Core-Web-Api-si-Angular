using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectDAW.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectDAW.Data
{
    public class ProiectContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, UserRole,
        IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProiectContext(DbContextOptions options) : base(options) { }

        public DbSet<Client> Clienti { get; set; }
        public DbSet<Comanda> Comenzi { get; set; }
        public DbSet<Adresa> Adrese { get; set; }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<ComandaProdus> ComandaProduse { get; set; }
        public DbSet<SessionToken> SessionTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ///One To Many
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Comenzi)
                .WithOne(co => co.Client);

            ///One To One
            modelBuilder.Entity<Client>()
                .HasOne(c => c.Adresa)
                .WithOne(adr => adr.Client);

            ///Many To Many
            modelBuilder.Entity<ComandaProdus>().HasKey(cp => new { cp.ComandaId, cp.ProdusId });

            modelBuilder.Entity<ComandaProdus>() ///One To Many intre Comanda si ComandaProdus
               .HasOne(cp => cp.Comanda)
               .WithMany(c => c.ComandaProduse)
               .HasForeignKey(cp => cp.ComandaId);

            modelBuilder.Entity<ComandaProdus>() ///One To Many intre Produs si ComandaProdus
                .HasOne(cp => cp.Produs)
                .WithMany(p => p.ComandaProduse)
                .HasForeignKey(cp => cp.ProdusId);

            ///Many To Many => User -> UserRole -> Role
            modelBuilder.Entity<UserRole>().HasKey(cp => new { cp.UserId, cp.RoleId });

            modelBuilder.Entity<UserRole>() 
               .HasOne(cp => cp.Role)
               .WithMany(c => c.UserRoles)
               .HasForeignKey(cp => cp.RoleId);

            modelBuilder.Entity<UserRole>() 
                .HasOne(cp => cp.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(cp => cp.UserId);

        }
    }
}
