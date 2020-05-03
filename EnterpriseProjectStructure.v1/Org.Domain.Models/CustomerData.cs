namespace Org.Domain.Models
{
    using System.IO;

    using Entities;

    public class CustomerData
    {
        public CustomerEntity Customer { get; set; }
        public Stream CustomerLogo { get; set; }

    }
}
