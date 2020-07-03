using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenFmiranda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( "WELCOME TO FOOTBALL SIMULATOR" );
            equipo e1 = new equipo("Arsenal","English",true);
            equipo e2 = new equipo("Leicestrer city", "English", true);

            e1.add_player();
            e1.add_medic();
            e1.add_trainer();
            e1.show_team_info();

            partido p1 = new partido(e1,e2);

            e1.injury += p1.OnInjury;
            e1.injury += p1.OnInjury;


          
        }

        private static void E1_injury(object source, EquipoEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
