using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
record Sale(int SaleId, int ProductId, int RequiedQuantity,
        double PriceWhithSale, bool IsClub, DateTime Startsale, DateTime FinishSale)
    {
    }
}
