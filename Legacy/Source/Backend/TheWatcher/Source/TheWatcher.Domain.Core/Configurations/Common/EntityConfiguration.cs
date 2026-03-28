using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatcher.Domain.Core.Common;

namespace TheWatcher.Domain.Core.Configurations.Common
{
    internal class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder
                .Property(p => p.Active)
                .HasColumnType("bit")
                .IsRequired()
                ;

            builder
                .Property(p => p.CreationUser)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsRequired()
                ;

            builder
                .Property(p => p.CreationDateTime)
                .HasColumnType("datetime")
                .IsRequired()
                ;

            builder
                .Property(p => p.LastUpdateUser)
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                ;

            builder
                .Property(p => p.LastUpdateDateTime)
                .HasColumnType("datetime")
                ;

            builder
                .Property(p => p.Version)
                .HasColumnType("rowversion")
                ;

            // Add configuration for row version

            builder
                .Property(p => p.Version)
                .ValueGeneratedOnAddOrUpdate()
                .IsRowVersion()
                ;
        }
    }
}
