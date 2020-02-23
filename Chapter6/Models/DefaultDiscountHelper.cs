using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chapter6.Models
{
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal total);
    }
    public class DefaultDiscountHelper : IDiscountHelper
    {
        //public decimal DiscountSize { get; set; }
        private decimal discountSize;
        public DefaultDiscountHelper(decimal discount)
        {
            discountSize = discount;
        }
        public decimal ApplyDiscount(decimal total)
        {
            //return (total - ((DiscountSize * total )/ 100 ));
            return (total - ((discountSize * total )/ 100 ));
        }
    }
}