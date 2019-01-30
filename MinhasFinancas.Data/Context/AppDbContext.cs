using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MinhasFinancas.Data.Mappings;
using MinhasFinancas.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MinhasFinancas.Data.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaMap());
            modelBuilder.ApplyConfiguration(new Plano_ContaMap());
            modelBuilder.ApplyConfiguration(new TransacaoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Plano_Conta> Plano_Contas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
