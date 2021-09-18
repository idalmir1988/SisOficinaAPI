using Microsoft.EntityFrameworkCore;
using OficinaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrdemServico>()
                .HasOne(ordem => ordem.Cliente)
                .WithMany(cliente => cliente.OrdensServicos)
                .HasForeignKey(ordem => ordem.ClienteId);
        }


        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<OrdemServico> OrdensServicos { get; set; }
    }
}
