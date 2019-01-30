using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhasFinancas.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasFinancas.Data.Mappings
{
    public class Plano_ContaMap : IEntityTypeConfiguration<Plano_Conta>
    {
        public void Configure(EntityTypeBuilder<Plano_Conta> builder)
        {
            builder.ToTable("Plano_Contas");
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasKey(p => p.Id);
        }
    }
}
