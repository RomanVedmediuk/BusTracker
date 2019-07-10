namespace BusTracker.Infrastructure.Contexts.Configurations
{
    using BusTracker.Infrastructure.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(m => m.CreatedOn).HasColumnType(DataConstants.SqlServer.DateTime2).HasDefaultValueSql(DataConstants.SqlServer.SysDateTime);
            builder.Property(p => p.UpdatedOn).HasColumnType(DataConstants.SqlServer.DateTime2);
        }
    }
}