using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chapter6.Models
{
    public class FlexibleDiscountHelper : IDiscountHelper
    {
        public decimal ApplyDiscount(decimal total)
        {
            decimal discount = total > 100 ? 95m : 25m;
            return (total-(discount*total/100));
        }
    }
}