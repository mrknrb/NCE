using System;

namespace Resources.Game.Elemek.Tanar.Actions
{
    public class ActionBaseClass
    {
        public GameMain gameMain { get; set; }
        public bool actionBefejezve { get; set; }
  
        public int prioritas { get; set; }
        public  Action actionStopEvent{ get; set; }

    

     

      public void actionVegemethod(bool sikeres)
        {
            if (sikeres)
            {
                actionBefejezve = true;
            }
         
            actionStopEvent?.Invoke();
        }
    }
}