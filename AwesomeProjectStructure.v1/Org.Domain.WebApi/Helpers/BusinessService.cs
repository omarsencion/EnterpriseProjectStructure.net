namespace Org.Domain.WebApi
{
    public class BusinessService<TService> : IBusinessService<TService> where TService : class
    {
        public TService Get()
        {
            return IocServiceStack.ServiceManager.GetService<TService>();
        }

        public TService Get(string name)
        {
            return IocServiceStack.ServiceManager.GetService<TService>(name);
        }
    }
}
