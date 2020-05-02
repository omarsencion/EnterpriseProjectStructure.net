namespace Org.Domain.Abstractions.Common
{
    using IocServiceStack;

    [Contract]
    public interface ILogger
    {
        void Debug(string message);
    }
}
