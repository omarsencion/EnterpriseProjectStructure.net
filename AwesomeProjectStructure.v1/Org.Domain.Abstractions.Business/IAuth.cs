namespace Org.Domain.Abstractions.Business
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using IocServiceStack;

    [Contract]
    public interface IAuth
    {
        void Validate();
    }
}
