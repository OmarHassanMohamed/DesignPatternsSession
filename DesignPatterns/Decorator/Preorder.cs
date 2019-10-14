using System;
using System.Linq;

namespace DesignPatterns.Decorator
{
    public class Preorder : OrderBase
    {
        public override double CalculateTotalOrderPrice()
        {
            Console.WriteLine("Calculating the total price of a preorder.");
            return products.Sum(x => x.Price) * 0.9;
        }
    }
}