namespace Org.Domain.Core.Common
{
    using Abstractions.Common;

    public class Settings : ISettings
    {
        public string ConnectionString { get; set; }
    }
}
