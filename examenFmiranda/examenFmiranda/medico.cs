using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenFmiranda
{
    public class medico : persona
    {
        private int exp;

        public medico(string name, int age, string nationality, int salary, int exp)
        {
            this.name = name;
            this.age = age;
            this.nationality = nationality;
            this.salary = salary;
            Exp = exp;


        }

        public int Exp { get => exp; set => exp = value; }
        public string Name { get => name; set => name = value; }
        public void evaluate(int degree, jugador injured, List<jugador> principals, List<jugador> reserve, entrenador trainer ) 
        {
            if (degree < 2) 
            {
                this.heal(injured);
                //curar
            
            }
            else if (degree >= 2) 
            {
                
                
               
            
            }
        
        }
        public void heal(jugador player) 
        {
            player.Injury = false;
        
        }
    }
}
