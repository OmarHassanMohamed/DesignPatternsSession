using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class FactoryPattern
    {
    }

    public abstract class AirConditionerFactory
    {
        public abstract IAirConditioner Create(double temperature);
    }

    public class CoolingFactory : AirConditionerFactory
    {
        public override IAirConditioner Create(double temperature) => new Cooling(temperature);
    }

    public class WarmingFactory : AirConditionerFactory
    {
        public override IAirConditioner Create(double temperature)=> new Warming(temperature);
    }

    // May be like that 
    //public class AirConditioner
    //{
    //    private readonly Dictionary<Actions, AirConditionerFactory> _airConditionerFactories;

    //    public AirConditioner()
    //    {
    //        _airConditionerFactories = new Dictionary<Actions, AirConditionerFactory>()
    //        {
    //            {Actions.Cooling, new CoolingFactory() },
    //            {Actions.Warming, new WarmingFactory() }
    //        };
    //    }
    //}

    // That Better 
    public class AirConditioner
    {
        private readonly Dictionary<Actions, AirConditionerFactory> _airConditionerFactories;

        public AirConditioner()
        {
            _airConditionerFactories = new Dictionary<Actions, AirConditionerFactory>();

            foreach (Actions action in Enum.GetValues(typeof(Actions)))
            {
                var factory = (AirConditionerFactory)Activator.CreateInstance(Type.GetType("DesignPatterns." + Enum.GetName(typeof(Actions), action) + "Factory"));
                _airConditionerFactories.Add(action,factory);
            }
        }

        public IAirConditioner ExecuteCreation(Actions action, double temprature) =>
            _airConditionerFactories[action].Create(temprature);
    }
}
