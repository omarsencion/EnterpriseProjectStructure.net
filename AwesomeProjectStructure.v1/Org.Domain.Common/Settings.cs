namespace Org.Domain.Common
{
    using Abstractions.Common;

    public class Settings : ISettings
    {
        public string ConnectionString { get; set; }
    }
}
