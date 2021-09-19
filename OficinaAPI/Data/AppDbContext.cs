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

            builder.Entity<ItemOrdemServico>()
                .HasOne(item => item.Servico)
                .WithMany(servico => servico.ItemOrdensServicos)
                .HasForeignKey(item => item.ServicoId);

            builder.Entity<ItemOrdemServico>()
                .HasOne(item => item.OrdemServico)
                .WithMany(ordem => ordem.ItemOrdensServicos)
                .HasForeignKey(item => item.OrdemServicoId);

            builder.Entity<OrdemServico>()
                .HasOne(ordem => ordem.Tecnico)
                .WithMany(tecnico => tecnico.OrdemServicos)
                .HasForeignKey(ordem => ordem.TecnicoId);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<OrdemServico> OrdensServicos { get; set; }
        public DbSet<ItemOrdemServico> ItemOrdemServicos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Tecnico> Tecnicos { get; set; }

    }
}
