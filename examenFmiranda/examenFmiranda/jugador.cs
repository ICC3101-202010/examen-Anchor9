using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenFmiranda
{
    public class jugador : persona
    {
        private int attack_p;
        private int defense_p;
        private int number;
        private bool goalkeeper;
        private string position;
        private bool injury = false;

        public jugador(string name, int age, string nationality, int salary, int attack_p, int defense_points, int number, bool goalkeeper, string position) 
        {
            this.name = name;
            this.age = age;
            this.nationality = nationality;
            this.salary = salary;
            Attack_p = attack_p;
            Defense_p = defense_points;
            Number = number;
            Goalkeeper = goalkeeper;
            Position = position;
            
        
        }

        public int Attack_p { get => attack_p; set => attack_p = value; }
        public int Defense_p { get => defense_p; set => defense_p = value; }
        public int Number { get => number; set => number = value; }
        public bool Goalkeeper { get => goalkeeper; set => goalkeeper = value; }
        public string Position { get => position; set => position = value; }
        public bool Injury { get => injury; set => injury = value; }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public int Salary { get => salary; set => salary = value; }
    }
}
