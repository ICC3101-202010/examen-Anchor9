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
        private int actual;

        public partido(List<equipo> teams)
        {


            Teams = teams;

        }

        public DateTime Duration { get => duration; set => duration = value; }

        public List<equipo> Teams { get => teams; set => teams = value; }

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
        private void Final_statistics()
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
        private void injuerd_player()
        {
            Random rnd = new Random();
            int injury = rnd.Next(0, 101);

            //si el porcentaje es menor a 16 entonces si o si habrá un lesionado
            if (injury < 16)
            {
                int player = rnd.Next(0, 11); //jufgador lesionado
                int degree = rnd.Next(1, 4); //grado de la lesion
                int team = rnd.Next(1, 3); // equipo del jugador

                jugador lesionado = Teams[team].Plantel[player];
                lesionado.Injury = true;
                Teams[team].Team_medic.evaluate(degree, lesionado);

            }




        }

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
        private void check_nationality(List<equipo> teams) 
        {
            foreach (equipo team in teams) 
            {
                int total = 11;
                int cont = 0;
                foreach (jugador player in team.Plantel)
                {
                    if (player.Nationality == team.Nationality)
                    {
                        cont++;

                    }
                    else if (player.Nationality != team.Nationality)
                    {


                    }


                }

                if (cont == total) 
                {
                    start = true;
                    continue;
                
                }
                else if (cont != total)
                {
                    start = false;
                    break;

                }




            }

        
        
        
        }

    }
}
