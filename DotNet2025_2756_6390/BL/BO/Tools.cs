using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BO
{
    internal static class Tools
    {
        public static string ToStringProperty<T>(this T obj)
        {
            // 1. תנאי עצירה למקרה שאין ערך
            if (obj == null) return "null";

            // 2. טיפול באוספים (רשימות/מערכים) - נכנסים לעומק הרשימה
            if (obj is IEnumerable enumerable && obj is not string)
            {
                var items = enumerable.Cast<object>().Select(item => item.ToStringProperty());
                return $"[{string.Join(", ", items)}]";
            }

            Type type = obj.GetType();

            // 3. טיפול בסוגים בסיסיים (מספרים, בוליאני, מחרוזות)
            if (type.IsPrimitive || type.IsValueType || type == typeof(string))
            {
                return type == typeof(string) ? $"\"{obj}\"" : obj.ToString();
            }

            // 4. חקירת האובייקט (Reflection) - שליפת כל התכונות הציבוריות
            var properties = type.GetProperties();

            // 5. הרכבת המחרוזת: שם התכונה והערך שלה
            var propStrings = properties.Select(prop =>
            {
                object value = prop.GetValue(obj);
                // קריאה חוזרת למתודה כדי לטפל במקרה שהערך הוא בעצמו אובייקט מורכב או רשימה
                string valueString = value.ToStringProperty();
                return $"{prop.Name}: {valueString}";
            });

            // עטיפת התוצאה בסוגריים מסולסלים כדי להראות שזה אובייקט
            return $"{{ {string.Join(", ", propStrings)} }}";
        }

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
