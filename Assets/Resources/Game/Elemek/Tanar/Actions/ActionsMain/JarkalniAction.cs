using System;
using Resources.Game.DataClassok;
using Resources.Game.Elemek.Tanar.Actions.ActionParts.Latas;
using Resources.Game.Elemek.Tanar.Actions.ActionParts.Mozgas;
using Random = UnityEngine.Random;

namespace Resources.Game.Elemek.Tanar.Actions.ActionsMain
{
    public class JarkalniAction :ActionBaseClass, ActionInterface

    {
        private Mozgas mozgas;
        private Latas latas;
        public JarkalniAction(GameMain gameMain2,Action actionStopEvent2)
        {
            gameMain = gameMain2;
            actionStopEvent = actionStopEvent2;
            prioritas = 3;
           
            //  cont = GameObject.Find ("Player") .GetComponent<Controller> ();
        }


      

        public void startAction()
        {
         
             mozgas = new Mozgas(gameMain);
            // mozgas.mozgasVege += mozgasVege;
            var coordinates = new Coordinates();
            coordinates.Y = Random.Range(0, gameMain.elemekGrid.GetLength(0));
            coordinates.X = Random.Range(0, gameMain.elemekGrid.GetLength(1));
            
         
            mozgas.ujCelpont(coordinates);
            mozgas.mozgasVege += actionVegemethod;




        }

        public void stopAction()
        {
            
        }

       
    }
}