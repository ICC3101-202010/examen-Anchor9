using System;
using System.Collections.Generic;
using System.Linq;
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


        public equipo(string name, string nationality, medico medic, entrenador trainer, bool liga) 
        {
            Name = name;
            Nationality = nationality;
            Team_medic = medic;
            Team_trainer = trainer;
            Liga = liga;
              
        }
        public string Name { get => name; set => name = value; }
        public string Nationality { get => nationality; set => nationality = value; }
        public medico Team_medic { get => team_medic; set => team_medic = value; }
        public List<jugador> Plantel { get => plantel; set => plantel = value; }
        public bool Liga { get => liga; set => liga = value; }
        public List<jugador> Principals { get => principals; set => principals = value; }
        internal entrenador Team_trainer { get => team_trainer; set => team_trainer = value; }
    }
}
