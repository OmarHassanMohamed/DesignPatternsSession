using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Composite;
using DesignPatterns.Decorator;
using DesignPatterns.FacetedBuilder;
using DesignPatterns.Strategy;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {

            // Factory Pattern
            var factory = new AirConditioner().ExecuteCreation(Actions.Cooling,20);
            factory.Operate();
            //---------------------------------------------------------------------

            //Facted Builder Pattern
            var car = new CarBuilderFacade()
                .Info
                  .WithColor("Black")
                  .WithNumberOfDoors(4)
                  .WithType("BMW")
                .Built
                  .AtAddress("Address")
                  .InCity("Alexandria")
                .Build();

            Console.WriteLine(car.ToString());

            //------------------------------------------------------------------------
            // Composite Pattern
            var phone = new SingleGift("Phone", 256);
            phone.CalculateTotalPrice();


            //composite gift
            var rootBox = new CompositeGift("RootBox", 0);
            var truckToy = new SingleGift("TruckToy", 289);
            var plainToy = new SingleGift("PlainToy", 587);
            rootBox.Add(truckToy);
            rootBox.Add(plainToy);
            var childBox = new CompositeGift("ChildBox", 0);
            var soldierToy = new SingleGift("SoldierToy", 200);
            childBox.Add(soldierToy);
            rootBox.Add(childBox);

            Console.WriteLine($"Total price of this composite present is: {rootBox.CalculateTotalPrice()}");
            //-----------------------------------------------------------------------
            // Decorator Pattern
            var regularOrder = new RegularOrder();
            Console.WriteLine(regularOrder.CalculateTotalOrderPrice());
            Console.WriteLine();

            var preOrder = new Preorder();
            Console.WriteLine(preOrder.CalculateTotalOrderPrice());
            Console.WriteLine();

            var premiumPreorder = new PremiumPreorder(preOrder);
            Console.WriteLine(premiumPreorder.CalculateTotalOrderPrice());

            //---------------------------------------------------------------------
            // Strategy Pattern

            var reports = new List<DeveloperReport>
            {
                new DeveloperReport {Id = 1, Name = "Dev1", Level = DeveloperLevel.Senior, HourlyRate = 30.5, WorkingHours = 160 },
                new DeveloperReport { Id = 2, Name = "Dev2", Level = DeveloperLevel.Junior, HourlyRate = 20, WorkingHours = 120 },
                new DeveloperReport { Id = 3, Name = "Dev3", Level = DeveloperLevel.Senior, HourlyRate = 32.5, WorkingHours = 130 },
                new DeveloperReport { Id = 4, Name = "Dev4", Level = DeveloperLevel.Junior, HourlyRate = 24.5, WorkingHours = 140 }
            };

            var calculatorContext = new SalaryCalculator(new JuniorDevSalaryCalculator());
            var juniorTotal = calculatorContext.Calculate(reports);
            Console.WriteLine($"Total amount for junior salaries is: {juniorTotal}");

            calculatorContext.SetCalculator(new SeniorDevSalaryCalculator());
            var seniorTotal = calculatorContext.Calculate(reports);
            Console.WriteLine($"Total amount for senior salaries is: {seniorTotal}");

            Console.WriteLine($"Total cost for all the salaries is: {juniorTotal + seniorTotal}");


            Console.Read();

        }
    }
}
