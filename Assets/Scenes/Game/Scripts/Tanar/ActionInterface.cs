using System;

namespace Scenes.Game.Scripts.Tanar
{
    public interface ActionInterface
    {
         event Action<bool> actionVege;
     
        void startAction();
        void stopAction();
        void actionVegemethod(bool sikeres);

    }
}