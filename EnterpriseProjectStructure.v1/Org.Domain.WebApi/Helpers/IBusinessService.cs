namespace Org.Domain.WebApi
{
    public interface IBusinessService <TService> where TService : class
    {
        TService Get();
        TService Get(string name);
    }
}
