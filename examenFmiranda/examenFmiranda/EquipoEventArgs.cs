using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenFmiranda
{
    public class EquipoEventArgs : EventArgs
    {
        private jugador injured;
        private entrenador trainer;
        private List<jugador> principals = new List<jugador>();
        private List<jugador> reserve = new List<jugador>();


        public jugador Injured { get => injured; set => injured = value; }
        public entrenador Trainer { get => trainer; set => trainer = value; }
        public List<jugador> Principals { get => principals; set => principals = value; }
        public List<jugador> Reserve { get => reserve; set => reserve = value; }
    }
}
