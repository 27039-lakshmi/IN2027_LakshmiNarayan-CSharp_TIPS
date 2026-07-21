namespace EmployeeManager.Models
{
    internal abstract class Employee
    {
        protected Employee(string name, string salary)
        {
            this.Name = name;
            this.Salary = decimal.Parse(salary);
        }
        protected string Name { get; set; }
        protected decimal Salary { get; set; }

        public abstract decimal CalculateBonus();
        public abstract void PrintDetails();
    }
}
