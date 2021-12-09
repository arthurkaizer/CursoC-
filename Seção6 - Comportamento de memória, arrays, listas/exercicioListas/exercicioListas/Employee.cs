using System.Globalization;
namespace exercicioListas
{
    class Employee
    {
        public int id { get; private set; }
        private string name { get; set; }
        private double salary { get; set; }

        public Employee() { }
        public Employee(int id, string name, double salary)
        {
            this.id = id;
            this.name = name;
            this.salary = salary;
        }

        public void increaseSalary(double percentage)
        {
            salary += salary * (percentage / 100);
        }

        public override string ToString()
        {
            return id + ", " + name + ", " + salary.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
