using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chapter6.Models
{
    public class LinqValueCalculator : IValueCalculator
    {
        IDiscountHelper discounter;
        public static int counter = 0;
        public LinqValueCalculator(IDiscountHelper discounter)
        {
            this.discounter = discounter;
            System.Diagnostics.Debug.WriteLine(string.Format($"Instance {counter++} created"));
        }
        
          
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            decimal value =  products.Aggregate(0.00m,(p,product)=>p+product.Price);
            return discounter.ApplyDiscount(value);
        }
    }

    public class ShoppingCart
    {
        private IValueCalculator cal;
        public ShoppingCart(IValueCalculator calcParam)
        {
            this.cal = calcParam;
        }
        public IEnumerable<Product> Products { get; set; }
        public decimal CalculateProductTotal()
        {
            return cal.ValueProducts(Products);
        }
    }
}