using APISysVentas.Aplicacion.Dominio.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APISysVentas.Aplicacion.Configuration
{
    public class UsersEntityConfiguration : BasesEntityConfiguration<Users>
    {
        public UsersEntityConfiguration()
        {
            TableName = "Users";
        }

        public override void Configure(EntityTypeBuilder<Users> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.HasKey(x => x.UserId);
            entityTypeBuilder.Property(x => x.UserId)
                .IsRequired()
                .IsUnicode(false);

            entityTypeBuilder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entityTypeBuilder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

        }
    }
}
