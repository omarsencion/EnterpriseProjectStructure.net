namespace Org.Domain.WebApi
{
    using Microsoft.AspNetCore.Mvc;

    using Models;
    using Org.Domain.Abstractions.Business;


    [Route("/api/CustomerForm")]
    public class CustomerController : Controller
    {
        IBusinessService<ICustomer> _customerService;
        public CustomerController(IBusinessService<ICustomer> customerService)
        {
            _customerService = customerService;
        }

        [HttpPost(nameof(Create))]
        public void Create([FromBody]CustomerData customer)
        {
            ModelState.Verify();

            //CustomerData customer = Request.GetObject<CustomerData>("Customer");
            //SetUploadedFileStream(customer);

            /* Save customer */
            using (var customerService = _customerService.Get())
            {
                customerService.Create(customer);
            }
        }

        [HttpPost(nameof(Update))]
        public void Update([FromBody]CustomerData customer)
        {
            ModelState.Verify();

            //CustomerData customer = Request.GetObject<CustomerData>("Customer");
            //SetUploadedFileStream(customer);

            /* Update customer */
            using (var customerService = _customerService.Get())
            {
                customerService.Update(customer);
            }
        }

        [HttpDelete(nameof(Delete))]
        public void Delete(int customerId)
        {
            /* Update customer */
            using (var customerService = _customerService.Get())
            {
                customerService.Delete(customerId);
            }
        }


        [HttpPost(nameof(Validate))]
        public string Validate([FromBody]CustomerData customer)
        {
            ModelState.Verify();

            using (var customerService = _customerService.Get())
            {
                return customerService.Validate(customer);
            }
        }

        #region Private Methods
        private void SetUploadedFileStream(CustomerData customer)
        {
            if (Request.Form.Files.Count > 0)
            {
                var customerLog = Request.Form.Files.GetFile("CustomerLogo");
                if (customerLog != null)
                {
                    customer.CustomerLogo = customerLog.OpenReadStream();
                }
            }
        }
        #endregion
    }
}
