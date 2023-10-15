namespace TT.Host.ConfigSections
{
    public class DisabledFunctionalConfigSection : IConfig
    {
        public static string Name => "disabledFunctionality";

        public static string Path => "root:disabledFunctionality";

        public Dictionary<string, string[]> DisabledFeatures { get; set; }

        public string[] DisabledControllers => DisabledFeatures["back"];

        public string[] UiDisabledFeatures => DisabledFeatures["ui"];
    }
}
