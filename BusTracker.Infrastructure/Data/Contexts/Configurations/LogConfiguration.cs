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
            builder.Property(_ => _.Id).HasDefaultValueSql(DataConstants.SqlServer.NewSequentialId);
            builder.HasIndex(_ => _.Id).HasName($"IX_{nameof(T)}_Id").ForSqlServerIsClustered(false);
            builder.Property(_ => _.CreatedOn).HasColumnType(DataConstants.SqlServer.DateTime2).HasDefaultValueSql(DataConstants.SqlServer.SysDateTime);
        }
    }
}