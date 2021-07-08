using System;

namespace Resources.Game.Elemek.Tanar.Actions.ActionsMain
{
    public class KutatasAction :ActionBaseClass,  ActionInterface
    {
       

        public KutatasAction(GameMain gameMain2,Action actionStopEvent)
        {
            gameMain = gameMain2;
           
            prioritas = 1;
        }


        public Action actionStopEvent { get; set; }

        public event Action actionVege;

        public void startAction()
        {
        }

        public void stopAction()
        {
        }

       
    }
}