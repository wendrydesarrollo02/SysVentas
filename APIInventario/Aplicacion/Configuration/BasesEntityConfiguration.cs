using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APISysVentas.Aplicacion.Configuration
{
    public abstract class BasesEntityConfiguration<TEntity>
        where TEntity : class
    {
        public string Schema { get; set; }
        public string TableName { get; set; }

        public virtual void Configure(EntityTypeBuilder<TEntity> entityTypeBuilder) 
        {
            if (string.IsNullOrEmpty(this.TableName))
                throw new ArgumentNullException(null, nameof(TableName));

            entityTypeBuilder.ToTable(TableName, schema: Schema);
            
        }
    }
}
