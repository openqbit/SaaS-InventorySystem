using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQbit.Inventory.Common.Models;

namespace OpenQbit.Inventory.BLL.BusinessService.Contr
{
    public interface ICustomerManager
    {
        bool RecoredCustomer(Customer customer);

        bool DeleteCustomer(Customer customer);

        bool UpdateCustomer(Customer customer);

        Customer SearchCustomerByUserName(string userName);

        Customer FindCustomerByID(int id);

        List<Customer> GetAllCustomers();
    }
}
