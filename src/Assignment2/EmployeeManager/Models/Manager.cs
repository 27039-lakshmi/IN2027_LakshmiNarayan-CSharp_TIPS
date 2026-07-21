namespace EmployeeManager.Models
{
    internal class Manager : Employee
    {
        public Manager(string name, string salary)
            : base(name, salary) 
        {
        }
        public override decimal CalculateBonus()
        {
            return Salary / 30;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"Employee Name {Name} \nPosition Manager \nSalary {Salary} \nBonus {CalculateBonus()}");
        }
    }
}
