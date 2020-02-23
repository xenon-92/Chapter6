using Chapter6.Models;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chapter6.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator cal;
        List<Product> _products = new List<Product>()
        {
            new Product(){Name="Kayak",Category="WaterSports" ,Price=275M},
            new Product(){Name="LifeJacket",Category="WaterSports" ,Price=48.95M},
            new Product(){Name="Soccer Ball",Category="Soccer" ,Price=19.50M},
            new Product(){Name="Corner Flag",Category="Soccer" ,Price=34.49M},
        };
        public HomeController(IValueCalculator calcParam, IValueCalculator cal2)
        {
            cal = calcParam;
        }
        // GET: Home
        public ActionResult Index()
        {
            /*
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            IValueCalculator cal = ninjectKernel.Get<IValueCalculator>();
             */
            //IValueCalculator cal = new LinqValueCalculator();
            ShoppingCart cart = new ShoppingCart(cal) { Products = _products };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}