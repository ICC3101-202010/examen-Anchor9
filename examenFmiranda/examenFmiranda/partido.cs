using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace examenFmiranda
{
    public class partido
    {
        private DateTime duration = new DateTime(0,0,0,1,30,0);
        private int[] result = new int[2];
        private List<equipo> teams = new List<equipo>();
        private string match_type;
        private int start = 0;
        private int min;
        private int hour;

        public partido(equipo team1, equipo team2)
        {
            Teams.Add(team1);
            Teams.Add(team2);
        }

        public DateTime Duration { get => duration; set => duration = value; }
        public List<equipo> Teams { get => teams; set => teams = value; }


        //Metodo que le avisa al partido cuando un jugador es lesionado y se cambia el jugador

        public void OnInjury(object source, EquipoEventArgs args)
        {
            args.Trainer.change_player(args.Reserve, args.Principals, args.Injured);
            Console.WriteLine(args.Injured.Name + "changed");

        }
        
        private void Check_team_type(List<equipo> teams)
        {
            if (teams[0].Liga == true && teams[1].Liga == true)
            {

                start++;
                match_type = "League match";

            }
            else if (teams[0].Liga == false && teams[1].Liga == false)
            {
                //chequear nacionalidad
                start++;
                match_type = "National match";



            }
            else if (teams[0].Liga == false && teams[1].Liga == true || teams[0].Liga == false && teams[1].Liga == true) 
            {

                Console.WriteLine("Both teams have diferent type team");
            
            }


        }
        

        
        public void Final_statistics()
        {
            Console.WriteLine("Result: " + result);
            Console.WriteLine("Duration: " + duration);

        }
        

        public delegate void GoalEventHanlder(object source, EventArgs args); 
        public event GoalEventHanlder goal;

        protected virtual void OnGoal()
        {
            if (goal != null)
            {
                goal(this, EventArgs.Empty); 
            }
        }
        public void Goal()
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
            this.Final_statistics();


        }

        
        public void play(List<equipo> teams)
        {
            //Simula el 
            this.Check_team_type(teams);
            if (start != 0)
            {
                int m = duration.Minute;
                int h = duration.Hour;
                min = 0;
                hour = 0;
                while (hour < m && hour < h)
                {
                    result[0] = 0;
                    result[1] = 0;
                    teams[0].injuerd_player();
                    teams[1].injuerd_player();
                    this.Goal();
                    min = 10 + min;
                    Thread.Sleep(2000);
                    if (min == 60) 
                    {
                        min = 0;
                        hour = 1;
                    
                    }

                }





            }
            else if (start == 0)
            {

                Console.WriteLine("Unsupported match");

            }


        }

       

    }
}
