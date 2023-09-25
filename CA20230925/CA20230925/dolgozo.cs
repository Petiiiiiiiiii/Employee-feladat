using System;
using System.Collections.Generic;
using System.Text;

namespace CA20230925
{
    class dolgozo
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public bool Gender { get; set; }
        public string MaritalStatus { get; set; }
        public int Salary { get; set; }
        public int YearlySalary { get; set; }
        public int YearlySalaryHUF { get; set; }

        public dolgozo(string sor)
        {
            var atmeneti = sor.Split(';');
            this.Name = atmeneti[0];
            this.Age = int.Parse(atmeneti[1]);
            this.City = atmeneti[2];
            this.Department = atmeneti[3];
            this.Position = atmeneti[4];
            this.Gender = atmeneti[5] == "Male";
            this.MaritalStatus = atmeneti[6];
            this.Salary = int.Parse(atmeneti[7]);
            this.YearlySalary = Salary * 12;
            this.YearlySalaryHUF = YearlySalary * 380;

        }
        public override string ToString()
        {
            return $"{this.Name, 10} | {this.Age,3} | {this.City,10} | {this.Department,10} | {this.Position,15} | {(this.Gender ? "Male" : "Female"),6} | {this.MaritalStatus,8} | {this.Salary,4}";
        }
    }
}
