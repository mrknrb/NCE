using System;
using System.Collections.Generic;
using ECASimulator.ECALibrary;
using ECASimulator.Structs;
using UnityEngine;

namespace ECASimulator.Tanar.ActionParts
{
    public class Mozgas
    {
       
        private List<Coordinates> ListOfCoordinates;
        private Main main;
        public event Action<bool> mozgasVege;
        private GameObject tanar2;
        private Coordinates finishCoordinata;

        public Mozgas( Main main2)
        {
           
            main = main2;
        }

        public void mozgasStop()
        {
            // main.update -= MozgasVhovaLoop;
            ListOfCoordinates?.Clear();
        }

        public void ujCelpont(Coordinates finishCoordinatabe)
        {
            
            mozgasStop();
      
            ListOfCoordinates = PathFinding.findPath(main.elemekGridClass.gridElements, aktualisPozicio(), finishCoordinatabe);
            finishCoordinata = ListOfCoordinates[ListOfCoordinates.Count - 1];

            main.update += MozgasVhovaLoop;
        }

        private Coordinates aktualisPozicio()
        {
            var coo = new Coordinates();
            coo.X = (int) Math.Round(main.tanar.tanarObject.transform.position.x);
            coo.Y = (int) Math.Round(- main.tanar.tanarObject.transform.position.z);
            return coo;
        }
        private void MozgasVhovaLoop()
        {
            if (ListOfCoordinates.Count != 0)
            {
                float step = 3 * Time.deltaTime; // calculate distance to move
                var pos = new Vector3();
                pos.x = ListOfCoordinates[0].X;
                pos.y = 0;
                pos.z = -ListOfCoordinates[0].Y;
                main.tanar.tanarObject.transform.position = Vector3.MoveTowards(main.tanar.tanarObject.transform.position, pos, step);


                if (Vector3.Distance(main.tanar.tanarObject.transform.position, pos) < 0.001f)
                {
                    ListOfCoordinates.RemoveAt(0);
                }
            }
            else
            {
             
                mozgasVege?.Invoke(finishCoordinata.X==aktualisPozicio().X&&finishCoordinata.Y==aktualisPozicio().Y);
                main.update -= MozgasVhovaLoop;
            }
        }

       
    }
}