using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dormamu.Web.Models
{
    //public class FotoProduto
    //{
    //    public long ID { get; set; }
    //    public string Extensao { get; set; }
    //    public int Tamanho { get; set; }
    //    public byte[] Foto { get; set; }
    //    public string TipoConteudo { get; set; }

    //    public Produto Produto { get; set; }
    //    public long ProdutoID { get; set; }
    //}

    //public class ImagemMap : IEntityTypeConfiguration<FotoProduto>
    //{
    //    public void Configure(EntityTypeBuilder<FotoProduto> builder)
    //    {
    //        builder.ToTable("FotoProduto");
    //        builder.HasKey(foto => foto.ID);
    //        builder.Property(foto => foto.ID);
    //        builder.Property(foto => foto.Extensao)
    //            .HasMaxLength(4)
    //            .IsRequired();
    //        builder.Property(foto => foto.Foto);
    //        builder.Property(foto => foto.ID);
    //        builder.Property(foto => foto.ID);
    //        builder.Property(foto => foto.ID);

    //    }
    //}
}