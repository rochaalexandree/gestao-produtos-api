using GestaoProdutos.Dominio.Entidades;
using GestaoProdutos.Dominio.ObjetosDeValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoProdutos.Infraestrutura.Mapeamentos
{
    public class FornecedorMapeamento : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasAlternateKey(p => p.Codigo);
            builder.Property(f => f.Codigo).ValueGeneratedOnAdd();

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(f => f.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Ignore(f => f.Notifications);
            builder.Ignore(p => p.Modificada);

            builder.OwnsOne(f => f.Cnpj, tj =>
            {
                tj.Property(c => c.Numero)
                    .IsRequired()
                    .HasMaxLength(Cnpj.CnpjTamanhoMaximo)
                    .HasColumnName("Cnpj")
                    .HasColumnType($"varchar({Cnpj.CnpjTamanhoMaximo})");

                tj.Ignore(c => c.Notifications);
            });

        }
    }
}
