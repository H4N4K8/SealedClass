
using System;
using System.Runtime.CompilerServices;

namespace Employees
{
    interface IEmployee
    {
        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Title { get; set; }

        public int Salary { get; set; }

        //Methods
        public string Fullname();
        public double Pay();
    }
    class Program
    {
        class Employee : IEmployee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Title { get; set; }

            public int Salary { get; set; }

            public Employee()
            {
                Id = 0;
                FirstName = string.Empty;
                LastName = string.Empty;
            }
            public Employee(int id, string firstName, string lastName)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
            }
            public string Fullname()
            {
                return FirstName + " " + LastName;
            }
            public virtual double Pay()
            {
                double salary;
                Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
                salary = double.Parse(Console.ReadLine());
                return salary;
            }

        }
        class Executive : Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Title { get; set; }
            public int Salary { get; set; }

            public Executive() : base()
            {
                Title = "";
                Salary = 0;
            }
            public Executive(int id, string firstName, string lastName, string title, int salary)
                : base(id, firstName, lastName)
            {
                Title = title; 
                Salary = salary;
            }

            sealed public override double Pay()
            {
                double salary;
                Console.WriteLine($"What is {this.Fullname()}'s weekly salary?");
                salary = double.Parse(Console.ReadLine());
                return salary;
            }
        }

        static void Main(string[] args)
        {
            // Employee object
            Employee Jolie = new Employee(5, "Joile", "Jefferson");
            Jolie.Pay();

            // Worker object created using parameterized constructor
            Executive freddy = new Executive(10, "Freddy", "Flintstone", "CEO", 100000);
            Console.WriteLine(freddy.Fullname());
            Console.WriteLine(freddy.Pay());

            //Worker object created using the default constructor
            //values are assigned using properties
            Employee geoff = new Employee();
            geoff.Id = 20;
            geoff.FirstName = "Geoff";
            geoff.LastName = "Fog";
            geoff.Title = "Line Worker";
            geoff.Salary= 60000;
            Console.WriteLine(geoff.Fullname());
            Console.WriteLine(geoff.Pay());

        }
    }
}