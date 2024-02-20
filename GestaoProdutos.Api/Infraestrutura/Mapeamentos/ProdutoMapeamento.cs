using GestaoProdutos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoProdutos.Infraestrutura.Mapeamentos
{
    public class ProdutoMapeamento : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasAlternateKey(p => p.Codigo);
            builder.Property(p => p.Codigo).ValueGeneratedOnAdd();

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Ignore(p => p.Notifications);
            builder.Ignore(p => p.Modificada);

            builder
                .HasOne(c => c.Fornecedor)
                .WithMany(c => c.Produtos)
                .HasForeignKey(c => c.FornecedorId);
        }
    }
}
