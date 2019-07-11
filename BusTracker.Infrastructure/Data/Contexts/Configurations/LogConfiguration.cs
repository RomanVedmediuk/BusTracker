namespace BusTracker.Infrastructure.Data.Contexts.Configurations
{
    using BusTracker.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public abstract class LogConfiguration<T> : IEntityTypeConfiguration<T>
        where T : Log
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(m => m.Id).HasDefaultValueSql(DataConstants.SqlServer.NewSequentialId);
            builder.Property(m => m.CreatedOn).HasColumnType(DataConstants.SqlServer.DateTime2).HasDefaultValueSql(DataConstants.SqlServer.SysDateTime);
        }
    }
}