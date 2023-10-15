namespace TT.Shared
{
    public class DataAccessParameters : Dictionary<string, string>
    {
        private string _lastConnectionString;

        public DataAccessParameters() : base()
        {
            _lastConnectionString = "";
        }

        public void ParseConnectionString(string connectionString)
        {
            if (connectionString == null)
            {
                throw new ArgumentNullException("No connection string provided.");
            }

            _lastConnectionString = connectionString;

            var connectionStringParts = connectionString.Split(';');
            
            foreach (var part in connectionStringParts)
            {
                if (!string.IsNullOrWhiteSpace(part))
                {
                    var partKeyValue = part.Split('=', StringSplitOptions.RemoveEmptyEntries);

                    var (key, value) = (partKeyValue[0], partKeyValue[1]);

                    Add(key, value);
                }
            }
        }
    }
}
