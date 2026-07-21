namespace EmployeeManager.Models
{
    internal class Developer : Employee
    {
        public Developer(string name, string salary) 
            :base(name, salary) { }
      
        public override decimal CalculateBonus()
        {
            return Salary / 10;
        }

        public override void PrintDetails()
        {
            Console.WriteLine($"Employee Name {Name} \nPosition Developer \nSalary {Salary} \nBonus {CalculateBonus()}");
        }
    }
}
