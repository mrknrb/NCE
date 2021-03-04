using System;
using ECASimulator.Structs;
using ECASimulator.Tanar.ActionParts;
using Random = UnityEngine.Random;

namespace ECASimulator.Tanar.Actions
{
    public class JarkalniAction : ActionInterface

    {
        private Main main;
        public event Action<bool> actionVege;
        public JarkalniAction(Main mainbe)
        {
            main = mainbe;
        }


        public void startAction()
        {
            var mozgas = new Mozgas(main);
            // mozgas.mozgasVege += mozgasVege;
            var coordinates = new Coordinates();
            coordinates.Y = Random.Range(0, main.elemekGridClass.gridElements.GetLength(0));
            coordinates.X = Random.Range(0, main.elemekGridClass.gridElements.GetLength(1));
            
         
            mozgas.ujCelpont(coordinates);
            mozgas.mozgasVege += actionVegemethod;




        }

        public void stopAction()
        {
        }

        public void actionVegemethod(bool sikeres)
        {
            actionVege?.Invoke(sikeres);
        }
    }
}