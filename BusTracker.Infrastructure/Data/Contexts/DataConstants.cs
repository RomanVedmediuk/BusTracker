namespace BusTracker.Infrastructure.Contexts
{
    public static class DataConstants
    {
        public static class SqlServer
        {
            public const string NewId = "NEWID()";
            public const string SysDateTime = "SYSDATETIME()";
            public const string SysUtcDateTime = "SYSUTCDATETIME()";
            public const string NewSequentialId = "NEWSEQUENTIALID()";
            public const string DateTime2 = "DATETIME2(2)";
        }
    }
}