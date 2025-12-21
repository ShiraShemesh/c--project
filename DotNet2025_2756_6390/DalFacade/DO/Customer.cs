using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
  public  record Customer(string CustomerId, string Name, string Address, string PhoneNumber)
    {
    }
}
