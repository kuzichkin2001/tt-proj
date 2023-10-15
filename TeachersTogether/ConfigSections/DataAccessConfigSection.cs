namespace TT.Service.ConfigSections
{
    public class DataAccessConfigSection : IConfig
    {
        public static string Name => "dataAccess";

        public static string Path => "root:dataAccess";

        public required string ConnectionString;
    }
}
