using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheWatcher.Domain.Core.Configurations.Common;
using TheWatcher.Domain.Core.Models;

namespace TheWatcher.Domain.Core.Configurations
{
    internal class ResourceWatchLogConfiguration : EntityConfiguration<ResourceWatchLog>
    {
        public override void Configure(EntityTypeBuilder<ResourceWatchLog> builder)
        {
            base.Configure(builder);

            // Set configuration for entity
            builder.ToTable("ResourceWatchLog", "dbo");

            // Set key for entity
            builder.HasKey(p => p.Id);

            // Set identity for entity (auto increment)
            builder.Property(p => p.Id).UseIdentityColumn();

            // Set configuration for columns
            builder
                .Property(p => p.Id)
                .HasColumnType("smallint")
                .IsRequired()
                ;

            builder
                .Property(p => p.ResourceWatchId)
                .HasColumnType("smallint")
                .IsRequired()
                ;

            builder
                .Property(p => p.AssemblyQualifiedName)
                .HasColumnType("nvarchar")
                .HasMaxLength(511)
                .IsRequired()
                ;

            builder
                .Property(p => p.ActionName)
                .HasColumnType("nvarchar")
                .HasMaxLength(511)
                .IsRequired()
                ;

            builder
                .Property(p => p.Successful)
                .HasColumnType("bit")
                .IsRequired()
                ;

            builder
                .Property(p => p.Message)
                .HasColumnType("nvarchar(max)")
                .IsRequired()
                ;

            builder
                .Property(p => p.ErrorMessage)
                .HasColumnType("nvarchar(max)")
                ;

            // Add configuration for foreign keys

            builder
                .HasOne(p => p.ResourceWatchFk)
                .WithMany(b => b.ResourceWatchLogList)
                .HasForeignKey(p => p.ResourceWatchId)
                .HasConstraintName("FK_dbo_ResourceWatchLog_ResourceWatchId_dbo_ResourceWatch")
                ;
        }
    }
}
