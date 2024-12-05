using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    internal class Customer
    {
        private static int _nextID = 1;

        private int code;
        private string name;
        private int age;
        private string cpf;

        public Customer(string name, int age, string cpf) {
            this.code = this.generateID();
            this.Name = name;
            this.Age = age;
            this.Cpf = cpf;
        }

        private int generateID()
        {
            return Customer._nextID++;
        }

        public int Code { get => code; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Cpf { get => cpf; set => cpf = value; }

        public override string ToString()
        {
            return $"Customer [Code: {Code}, Name: {Name}, Age: {Age}, CPF: {Cpf}]";
        }

    }

    
}
