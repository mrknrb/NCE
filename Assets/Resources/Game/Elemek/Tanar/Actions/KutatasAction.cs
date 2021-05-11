using System;

namespace Resources.Game.Elemek.Tanar.Actions
{
    public class KutatasAction : ActionInterface
    {
        public GameMain GameMain { get; set; } 
        public int prioritas { get; }
        public event Action<bool> actionVege;

        public KutatasAction(GameMain mainbe)
        {
            
            GameMain = mainbe;
            prioritas = 1;
        }

        public void startAction()
        {
        }

        public void stopAction()
        {
        }

        public void actionVegemethod(bool sikeres)
        {
        }
    }
}