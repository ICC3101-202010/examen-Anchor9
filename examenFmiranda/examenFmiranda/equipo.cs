using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace examenFmiranda
{
    public class equipo
    {
        private string name;
        private string nationality;
        private medico team_medic;
        private entrenador team_trainer;
        private List<jugador> plantel = new List<jugador>();
        private List<jugador> principals = new List<jugador>();
        private List<jugador> reserve = new List<jugador>();
        private bool liga;

      
        public equipo(string name, string nationality, bool liga)
        {
            Name = name;
            Nationality = nationality;
            Liga = liga;

        }
        public string Name { get => name; set => name = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public medico Team_medic { get => team_medic; set => team_medic = value; }
        public List<jugador> Plantel { get => plantel; set => plantel = value; }
        public bool Liga { get => liga; set => liga = value; }
        public List<jugador> Principals { get => principals; set => principals = value; }
        public List<jugador> Reserve { get => reserve; set => reserve = value; }
        internal entrenador Team_trainer { get => team_trainer; set => team_trainer = value; }

        public void add_medic()
        {
            Console.WriteLine("Medic name");
            string name = Console.ReadLine();

            Console.WriteLine("Medic age");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Medic nationality");
            string nationality = Console.ReadLine();

            Console.WriteLine("Medic salary");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Medic experience points");
            int exp = Convert.ToInt32(Console.ReadLine());

            medico medic = new medico(name, age, nationality, salary, exp);
            Console.Clear();
            team_medic = medic;


        }
        public void add_trainer()
        {
            Console.WriteLine("Trainer name");
            string name = Console.ReadLine();

            Console.WriteLine("Trainer age");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Trainer nationality");
            string nationality = Console.ReadLine();

            Console.WriteLine("Trainer salary");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Trainer tactic points");
            int tp = Convert.ToInt32(Console.ReadLine());

            entrenador trainer = new entrenador(name, age, nationality, salary, tp);
            Console.Clear();
            team_trainer = trainer;


        }

        public void add_player()
        {
            Console.WriteLine("Player name");
            string name = Console.ReadLine();

            Console.WriteLine("Player age");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Player nationality");
            string nationality = Console.ReadLine();

            Console.WriteLine("Player salary");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Player attack points");
            int ap = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Player defense points");
            int dp = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Player number");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("is goalkeeper? [Y/N]");
            string option = Console.ReadLine();

            Console.WriteLine("Player position");
            string position = Console.ReadLine();
            bool gkp = false;
            if (option == "Y" || option == "y")
            {
                gkp = true;

            }
            else if (option == "N" || option == "n")
            {
                gkp = false;

            }



            jugador player = new jugador(name, age, nationality, salary, ap, dp, number, gkp, position);
            Console.Clear();
            this.check_player_nationality(player);

        }

        public void check_player_nationality(jugador player)
        {

            if (liga == false)
            {
                if (player.Nationality == this.Nationality)
                {
                    plantel.Add(player);

                }

            }
            else if (liga == true)
            {
                plantel.Add(player);
                

            }


        }

        public void show_team_info()
        {
            Console.WriteLine("Team name: " + Name);
            Console.WriteLine("Team nationality: " + Nationality);
            Console.WriteLine("Team medic: " + team_medic.Name);
            Console.WriteLine("Team trainer: " + team_trainer.Name);
            Console.WriteLine(" ");
            Console.WriteLine("PLAYERS:");
            foreach (jugador player in plantel)
            {
                Console.WriteLine("Name:" + player.Name);
                Console.WriteLine("Age" + player.Age);
                Console.WriteLine("Nstionality: " + player.Nationality);
                Console.WriteLine(" ");

            }



        }

        public delegate void InjuryEventHanlder(object source, EquipoEventArgs args);
        public event InjuryEventHanlder injury;

        protected virtual void OnInjury(jugador lesionado, entrenador trainer, List<jugador> principals, List<jugador> reserve)
        {
            if (injury != null)
            {
                injury(this, new EquipoEventArgs() { Injured = lesionado, Trainer = trainer, Principals = principals, Reserve =reserve })  ;
            }
        }
        public void injuerd_player()
        {
            Random rnd = new Random();
            int injury = rnd.Next(0, 101);

            //si el porcentaje es menor a 16 entonces si o si habrá un lesionado
            if (injury < 16)
            {
                int player = rnd.Next(0, 11); //jufgador lesionado
                int degree = rnd.Next(1, 4); //grado de la lesion
                int team = rnd.Next(1, 3); // equipo del jugador

                jugador lesionado = Plantel[player];
                lesionado.Injury = true;

                OnInjury(lesionado, team_trainer, Principals, Reserve);

            }
        }
    }



}
   