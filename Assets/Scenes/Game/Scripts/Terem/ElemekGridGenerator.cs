using System.Collections.Generic;
using System.Linq;
using Scenes.Game.Scripts.Elemek;
using Scenes.Game.Scripts.Structs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scenes.Game.Scripts.Terem
{
    public static class ElemekGridGenerator
    {
      

       

        public static Elem[,] generalas(Mentes mentes)
        {
            int elemid = -1;
            int padid = -1;
            int tanuloid = -1;
            var entranceNumbers = oszlopEntranceNumbersGenerator(mentes.oszlop, mentes.duplaPad);

            Elem[,] grid = new Elem[osszesoszlop(mentes), osszessor(mentes)];
            
            var hanyadiktanulolist = hanyadiktanulo(mentes);
            var puskazok = hanyadiktanulolist.Take(mentes.puskazokszama);

            Listkevero.Shuffle(hanyadiktanulolist);
            //------------------------------------------------------------------------------------------------------------------------grid megtöltése
            for (int sor = 0; sor < grid.GetLength(1); sor++)
            {
                for (int oszlop = 0; oszlop < grid.GetLength(0); oszlop++)
                {
                    var elem = new Elem();
                    elem.tipus = "pad";
                    elem.puskazo = false;
                    elem.tanuloid = 0;
                    //-----------------------------------------------------------------------Padok generálás
                    if (sor == 0 || sor == 1 || sor == 2 || sor == grid.GetLength(1) - 1) //sor
                    {
                        elem.tipus = "ures";
                    }

                    //---------------------------------------


                    if (oszlop == 0 || oszlop == grid.GetLength(0) - 1)
                    {
                        elem.tipus = "ures";
                    }


                    foreach (var entranceNumber in entranceNumbers)
                    {
                        if (oszlop == entranceNumber)
                        {
                            elem.tipus = "ures";
                        }
                    }

                    //---------------------------------------------------------------------Üres terem legenerálva
                    if (elem.tipus == "pad")
                    {
                        padid++;

                        foreach (var tanulosorszam in hanyadiktanulolist)
                        {
                            if (tanulosorszam == padid)
                            {
                                tanuloid++;
                                elem.tanuloid = tanuloid;
                                elem.tipus = "tanulo";

                                foreach (var sorszam in puskazok)
                                {
                                    if (sorszam == tanulosorszam)
                                    {
                                        elem.puskazo = true;
                                    }
                                }
                            }
                        }
                    }


                    //---------------------tanulok és puskazok berakasa

                    elemid++;
                    elem.elemid = elemid;
                    elem.padid = padid;
                    elem.karma = karmagenerator(elem.puskazo);

                    grid[oszlop, sor] = elem;
                }
            }

           return grid;
        }

        public static Elem[,] GeneralasGameObjectek(Elem[,] gridElements)
        {
            var gridElements2 = gridElements;
            for (int oszlop = 0; oszlop < gridElements2.GetLength(0); oszlop++)
            {
                for (int sor = 0; sor < gridElements2.GetLength(1); sor++)
                {
                    var elem = gridElements2[oszlop, sor];
                    if (elem.tipus == "ures")
                    {
                        GameObject instance = GameObject.Instantiate(Resources.Load("Padlo", typeof(GameObject))) as GameObject;
                        instance.transform.Translate(oszlop, 0, -sor);
                        elem.gameObject = instance;
                    }

                    if (elem.tipus == "pad")
                    {
                        GameObject instance = GameObject.Instantiate(Resources.Load("Pad", typeof(GameObject))) as GameObject;
                        instance.transform.Translate(oszlop, 0, -sor);
                        elem.gameObject = instance;
                    }

                    if (elem.tipus == "tanulo")
                    {
                        GameObject instance = GameObject.Instantiate(Resources.Load("Tanulo", typeof(GameObject))) as GameObject;
                        instance.transform.Translate(oszlop, 0, -sor);
                        var tanuloComponent = instance.GetComponent<Tanulo>();
                        tanuloComponent.GridElem = elem;
                        elem.gameObject = instance;
                    }
                }
                
            }

            return gridElements2;
        }

        private static int karmagenerator(bool puskazo)
        {
            int karma = 0;
            if (puskazo)
            {
                karma = Random.Range(10, 30);
            }
            else
            {
                karma = Random.Range(0, 15);
            }

            return karma;
        }

        private static List<int> hanyadiktanulo(Mentes mentes)
        {
            //visszadob annyi padid-t, amennyi tanulo van a mentesi beallitasok szerint
            int osszeshely = mentes.sor * mentes.oszlop;
            var padidlistatanulo = new List<int>();

            var padidlistacheater = new List<int>();

       
            void random()
            {
                if (mentes.egyhelykihagy)
                {
                   var fele=  Kozos.RandomUniqueNumberGenerator.GenerateRandom(mentes.tanulokszama, 0, osszeshely / 2);
                   foreach (var padid in fele)
                   {
                       padidlistatanulo.Add(padid*2);
             
                   }
                }
                else
                {
                    padidlistatanulo=  Kozos.RandomUniqueNumberGenerator.GenerateRandom(mentes.tanulokszama, 0, osszeshely);
                }

               
         
            }

            void elol()
            {
                int elozopad = -1;
                for (int i = 0; i < mentes.tanulokszama; i++)
                {
                    if (mentes.egyhelykihagy)
                    {
                        elozopad += 2;
                    }
                    else
                    {
                        elozopad++;
                    }

                    padidlistatanulo.Add(elozopad);
                }
            }

            if (mentes.randomulesrend)
            {
                random();
            }
            else
            {
                elol();
            }

            return padidlistatanulo;
        }

        private static int[] oszlopEntranceNumbersGenerator(int oszlopszam, bool duplapadok)
        {
            if (oszlopszam == 2)
            {
                if (duplapadok)
                {
                    int[] myNum = { };
                    return myNum;
                }
                else
                {
                    int[] myNum = {2};
                    return myNum;
                }
            }

            if (oszlopszam == 4)
            {
                if (duplapadok)
                {
                    int[] myNum = {3};
                    return myNum;
                }
                else
                {
                    int[] myNum = {2, 4, 6};
                    return myNum;
                }
            }

            if (oszlopszam == 6)
            {
                if (duplapadok)
                {
                    int[] myNum = {3, 6};
                    return myNum;
                }
                else
                {
                    int[] myNum = {2, 4, 6, 8, 10};
                    return myNum;
                }
            }

            if (oszlopszam == 8)
            {
                if (duplapadok)
                {
                    int[] myNum = {3, 6, 9};
                    return myNum;
                }
                else
                {
                    int[] myNum = {2, 4, 6, 8, 10, 12, 14};
                    return myNum;
                }
            }

            int[] myNum2 = { };
            return myNum2;
        }


        private static int osszesoszlop(Mentes mentes)
        {
            int EntranceSzam = 0;
            if (mentes.duplaPad)
            {
                EntranceSzam = (mentes.oszlop / 2) - 1;
            }

            else
            {
                EntranceSzam = mentes.oszlop - 1;
            }

            var osszesoszlop = 2 + mentes.oszlop + EntranceSzam;
            return osszesoszlop;
        }

        private static int osszessor(Mentes mentes)
        {
            var osszessor = mentes.sor + 3 + 1;
            return osszessor;
        }
    }
}