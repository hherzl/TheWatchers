using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatchers.Domain.Common;

namespace TheWatchers.Infrastructure.Persistence.Configurations.Common;

internal class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(p => p.Active).HasColumnType("bit").IsRequired();
    }
}
