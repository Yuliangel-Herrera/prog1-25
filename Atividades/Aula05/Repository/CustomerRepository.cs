using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository
    {
        public CustomerRepository Retrieve()
        {
            return new CustomerRepository();
        }
        public void Save(CustomerRepository customer)
        {
        }
    }
}
