using System;

namespace Resources.Game.Elemek.Tanar.Actions
{
    public interface ActionInterface
    {
        GameMain gameMain { get; set; }
       bool actionBefejezve { get; set; }
        Action actionStopEvent{ get; set; }
        int prioritas { get; set; }
     
     
        void startAction();
        void stopAction();
        void actionVegemethod(bool sikeres);

    }
}