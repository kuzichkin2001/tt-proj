namespace TT.Service.ViewModels
{
    public class ConfigurationViewModel
    {
        public required string DataHost { get; set; }
        
        public required string DataStorageName { get; set; }

        public required string DbPort { get; set; }

        public required string DbUser { get; set; }

        public required string DbPassword { get; set; }
    }
}
