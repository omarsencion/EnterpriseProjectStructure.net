namespace Org.Domain.Storage
{
    using System;
    using IocServiceStack;

    using Org.Domain.Abstractions.Storage;

    [Service]
    public class Storage : IStorage
    {
        public byte[] Read(string fileName)
        {
            throw new NotImplementedException();
        }

        public void Write(string fileName, byte[] bytes)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
