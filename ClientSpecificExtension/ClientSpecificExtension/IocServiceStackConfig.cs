namespace ClientSpecificExtension
{
    using IocServiceStack;
    using Org.Domain.Abstractions.Business;
    
    public class IocServiceStackConfig
    {
        public static void Configure(IocContainer container)
        {
            container
                .GetRootContainer()
                    .Replace<ICustomerValidator>(typeof(XyzCustomerValidator));
        }
    }
}
