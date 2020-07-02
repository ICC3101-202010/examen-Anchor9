using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenFmiranda
{
    public class entrenador : persona
    {
        private int tactic_points;

        public entrenador(string name, int age, string nationality, int salary, int tactic_pionts)
        {
            this.name = name;
            this.age = age;
            this.nationality = nationality;
            this.salary = salary;
            Tactic_points = tactic_pionts;


        }

        public int Tactic_points { get => tactic_points; set => tactic_points = value; }
        public string Name { get => name; set => name = value; }

        public void change_player(List<jugador> reserve, List<jugador> principals, jugador injured)
        {
            Random rnd = new Random();
            int cant_reserva = reserve.Count;
            int numero_new_player = rnd.Next(0, cant_reserva );

            principals.Remove(injured);
            if (reserve[numero_new_player].Injury == false) 
            {
                principals.Add(reserve[numero_new_player]);
            }



        }
    }


}
