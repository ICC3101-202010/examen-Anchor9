using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenFmiranda
{
    public class partido
    {
        private DateTime duration;
        private int[] result = new int[2];
        private List<equipo> teams = new List<equipo>();
        private bool start = false;

        public partido(List<equipo> teams)
        {
            Teams = teams;
        }

        public DateTime Duration { get => duration; set => duration = value; }
        public List<equipo> Teams { get => teams; set => teams = value; }


        //Metodo que le avisa al partido cuando un jugador es lesionado y se cambia el jugador

        public void OnInjury(object source, EquipoEventArgs args)
        {
            args.Trainer.change_player(args.Reserve, args.Principals, args.Injured);

        }
        /*
        private void Check_team_type(List<equipo> teams)
        {
            if (teams[0].Liga == true && teams[1].Liga == true)
            {

                start = true;

            }
            else if (teams[0].Liga == false && teams[1].Liga == false)
            {
                //chequear nacionalidad
                this.check_nationality(teams);
                

            }


        }
        */

        /*
        private void Final_statistics()
        {
            Console.WriteLine("Result: " + result);
            Console.WriteLine("Duration: " + duration);

        }
        */

        public delegate void GoalEventHanlder(object source, EventArgs args); 
        public event GoalEventHanlder goal;

        protected virtual void OnGoal()
        {
            if (goal != null)
            {
                goal(this, EventArgs.Empty); 
            }
        }
        private void Goal()
        {
            Random rnd = new Random();
            int random1 = rnd.Next(0, 101);
            if (random1 < 25)
            {
                int team_goal = rnd.Next(0, 2);
                if (team_goal == 1)
                {
                    result[1]++;
                    OnGoal();
                }
                else if (team_goal == 0)
                {
                    result[0]++;
                    OnGoal();
                }
            }


        }

        /*
        private void play(List<equipo> teams)
        {
            this.Check_team_type(teams);
            if (start == true)
            {



            }
            else if (start == false)
            {

                //el partido no se puede continuar

            }


        }
        *
        */
       

    }
}
