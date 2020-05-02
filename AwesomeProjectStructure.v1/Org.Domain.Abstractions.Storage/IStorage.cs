namespace Org.Domain.Abstractions.Storage
{
    using System;
    using IocServiceStack;

    [Contract]
    public interface IStorage : IDisposable
    {
        void Write(string fileName, byte[] bytes);
        byte[] Read(string fileName);
    }
}
