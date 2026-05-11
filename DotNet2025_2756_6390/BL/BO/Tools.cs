using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    internal static class Tools
    {

        public static BO.Customer convert(this DO.Customer customer)
        {
            return new BO.Customer
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber,
            };
        }

        public static BO.Product convert(this DO.Product product)
        {
            return new BO.Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Category = (Categories?)product.Category,
                Price = product.Price,
                QuantityInStock = product.QuantityInStock,
                Sales = new List<SaleInProduct>()
            };
        }

        public static BO.Sale convert(this DO.Sale sale)
        {
            return new BO.Sale
            {
                SaleId = sale.SaleId,
                ProductId = sale.ProductId,
                RequiedQuantity = sale.RequiedQuantity??0,
                PriceWhithSale = sale.PriceWhithSale ?? 0,
                IsClub = sale.IsClub??false,
                Startsale = sale.Startsale?? DateTime.MinValue,
                FinishSale = sale.FinishSale?? DateTime.MaxValue

            };
        }

        public static DO.Customer convert(this BO.Customer client)
        {
            return new DO.Customer
            {
                CustomerId = client.CustomerId,
                Name = client.Name,
                Address = client.Address,
                PhoneNumber = client.PhoneNumber,
   
            };
        }

        public static DO.Product convert(this BO.Product product)
        {
            return new DO.Product
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Category = (DO.Categories?)product.Category,
                Price = product.Price,
                QuantityInStock = product.QuantityInStock
            };
        }
        public static DO.Sale convert(this BO.Sale sale)
        {
            return new DO.Sale
            {
                SaleId = sale.SaleId,
                ProductId = sale.ProductId,
                RequiedQuantity = sale.RequiedQuantity,
                PriceWhithSale = sale.PriceWhithSale,
                IsClub = sale.IsClub,
                Startsale = sale.Startsale,
                FinishSale = sale.FinishSale
            };
        }
    }
}
