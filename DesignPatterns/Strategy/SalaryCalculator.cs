using System.Collections.Generic;

namespace DesignPatterns.Strategy
{
    public class SalaryCalculator
    {
        private ISalaryCalculator _calculator;

        public SalaryCalculator( ISalaryCalculator salaryCalculator)
        {
            _calculator = salaryCalculator;
        }

        public void SetCalculator(ISalaryCalculator salaryCalculator) => _calculator = salaryCalculator;

        public  double Calculate(IEnumerable<DeveloperReport> reports) => _calculator.CalculateTotalSalary(reports);
    }
}