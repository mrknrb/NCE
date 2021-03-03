using System;

namespace ECASimulator.Tanar
{
    public interface ActionInterface
    {
         event Action<bool> actionVege;
     
        void startAction();
        void stopAction();
        void actionVegemethod(bool sikeres);

    }
}