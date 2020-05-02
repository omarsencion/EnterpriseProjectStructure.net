namespace Org.Domain.WebApi.Admin
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    using Entities;
    using Abstractions.Business;

    [Route("/api/customer")]
    public class CustomerController : Controller
    {
        readonly IBusinessService<ICustomerQuery> _customerService;
        public CustomerController(IBusinessService<ICustomerQuery> customerService)
        {
            _customerService = customerService;
        }

        [HttpGet(nameof(GetList))]
        public IList<CustomerEntity> GetList()
        {
            using (var service = _customerService.Get())
            {
                return service.GetCustomers();
            }
        }
    }
}
