using System;
using System.Collections.Generic;
using ECASimulator.Structs;
using ECASimulator.Terem;
using UnityEngine;

namespace ECASimulator.ECALibrary
{
    public static class PathFinding
    {
        private static Coordinates start;
        private static Coordinates finish;
        private static Elem[,] grid;
        private static FindPathElem[,] findPathElemGrid;

        public static List<Coordinates> findPath(Elem[,] gridOfMap, Coordinates startCoordinates, Coordinates finishCoordinates)
        {
            
            start = startCoordinates;
            finish = finishCoordinates;
            grid = gridOfMap;
            findPathElemGrid = new FindPathElem[grid.GetLength(0), grid.GetLength(1)];
            var eredmeny = new List<Coordinates>();

            if (finishCoordinates.X < 0 || finishCoordinates.X > findPathElemGrid.GetLength(0) - 1 || finishCoordinates.Y < 0 || finishCoordinates.Y > findPathElemGrid.GetLength(1) - 1)
            {
                eredmeny.Add(startCoordinates);
            }
            else if (grid[finishCoordinates.X, finishCoordinates.Y].tipus == "tanulo")
            {
                tanuloKozeliKoordinatak();
                korbenezes2();
            }
            else
            {
                korbenezes2();
            }

            void korbenezes2()
            {
                korbenezes(startCoordinates);
                //legkisebb megkeresése
                for (int i = 0; i < 1000; i++)
                {
                    var legkisebbCoordinata = legkisebbMegkeresese();
                    if (legkisebbCoordinata.X == finish.X && legkisebbCoordinata.Y == finish.Y)
                    {
                        i = 1001;
                    }
                    else
                    {
                        korbenezes(legkisebbCoordinata);
                    }
                }

                eredmeny = eredmenyVisszavezetese();
            }

            ;


            return eredmeny;
        }

     
        private static List<Coordinates> eredmenyVisszavezetese()
        {
            var eredmenyCoordinates = new List<Coordinates> { };
            eredmenyCoordinates.Add(finish);
            for (int i = 0; i < 1000; i++)
            {
                if (eredmenyCoordinates[eredmenyCoordinates.Count - 1].X == start.X && eredmenyCoordinates[eredmenyCoordinates.Count - 1].Y == start.Y)
                {
                    i = 1001;
                }
                else
                {
                    var utolsoElem = findPathElemGrid[eredmenyCoordinates[eredmenyCoordinates.Count - 1].X, eredmenyCoordinates[eredmenyCoordinates.Count - 1].Y];


                    eredmenyCoordinates.Add(utolsoElem.elozoKoordinata);
                }
            }

            eredmenyCoordinates.Reverse();
            return eredmenyCoordinates;
        }

        private static Coordinates legkisebbMegkeresese()
        {
            Coordinates legkisebbTavolsagElemCoordinata;
            legkisebbTavolsagElemCoordinata.X = 0;
            legkisebbTavolsagElemCoordinata.Y = 0;
            int legkisebbTavolsagOsszeg = 10000;
            int legkisebbTavolsagCeltol = 10000;
            for (int i = 0; i < findPathElemGrid.GetLength(0); i++)
            {
                for (int j = 0; j < findPathElemGrid.GetLength(1); j++)
                {
                    if (findPathElemGrid[i, j].csekkolva != true)
                    {
                        if (legkisebbTavolsagOsszeg > findPathElemGrid[i, j].TavolsagOsszeg && findPathElemGrid[i, j].TavolsagOsszeg != 0)
                        {
                            legkisebbTavolsagOsszeg = findPathElemGrid[i, j].TavolsagOsszeg;
                            legkisebbTavolsagCeltol = findPathElemGrid[i, j].finishTavolsag;

                            legkisebbTavolsagElemCoordinata.X = i;
                            legkisebbTavolsagElemCoordinata.Y = j;
                        }
                        else if (legkisebbTavolsagOsszeg == findPathElemGrid[i, j].TavolsagOsszeg && legkisebbTavolsagCeltol > findPathElemGrid[i, j].finishTavolsag)
                        {
                            legkisebbTavolsagOsszeg = findPathElemGrid[i, j].TavolsagOsszeg;
                            legkisebbTavolsagCeltol = findPathElemGrid[i, j].finishTavolsag;

                            legkisebbTavolsagElemCoordinata.X = i;
                            legkisebbTavolsagElemCoordinata.Y = j;
                        }
                    }
                }
            }

            return legkisebbTavolsagElemCoordinata;
        }

        private static void korbenezes(Coordinates koordinata)
        {
            findPathElemGrid[koordinata.X, koordinata.Y].csekkolva = true;

            void korbenezes2(Coordinates koordinata2)
            {
                
                if (tavolsagKalkulator(koordinata2, finish) +  findPathElemGrid[koordinata.X, koordinata.Y].startTavolsag + setaNeehezseg() <
                    findPathElemGrid[koordinata2.X, koordinata2.Y].TavolsagOsszeg || findPathElemGrid[koordinata2.X, koordinata2.Y].TavolsagOsszeg == 0)
                {
                    findPathElemGrid[koordinata2.X, koordinata2.Y].finishTavolsag = tavolsagKalkulator(koordinata2, finish);
                    findPathElemGrid[koordinata2.X, koordinata2.Y].startTavolsag = findPathElemGrid[koordinata.X, koordinata.Y].startTavolsag + setaNeehezseg();
                    findPathElemGrid[koordinata2.X, koordinata2.Y].TavolsagOsszeg = tavolsagKalkulator(koordinata2, finish) + findPathElemGrid[koordinata.X, koordinata.Y].startTavolsag + 1;
                    findPathElemGrid[koordinata2.X, koordinata2.Y].elozoKoordinata = koordinata;
                }
            }

            int setaNeehezseg()
            {
                int setanehezseg = 1;
                if (grid[koordinata.X, koordinata.Y].tipus=="pad")
                {
                    setanehezseg = 5;
                }

                return setanehezseg;
            }

            if (koordinata.Y != findPathElemGrid.GetLength(1) - 1)
            {
                if (grid[koordinata.X, koordinata.Y + 1].tipus != "tanulo" && grid[koordinata.X, koordinata.Y + 1].tipus != "pad")
                {
                    var coo = koordinata;
                    coo.Y++;
                    korbenezes2(coo);
                }
            }

            if (koordinata.X != findPathElemGrid.GetLength(0) - 1)
            {
                if (grid[koordinata.X + 1, koordinata.Y].tipus != "tanulo")
                {
                    var coo = koordinata;
                    coo.X++;
                    korbenezes2(coo);
                }
            }


            if (koordinata.Y != 0)
            {
                if (grid[koordinata.X, koordinata.Y - 1].tipus != "tanulo" && grid[koordinata.X, koordinata.Y - 1].tipus != "pad"&&grid[koordinata.X, koordinata.Y ].tipus != "pad")
                {
                    var coo = koordinata;
                    coo.Y--;
                    korbenezes2(coo);
                }
            }

            if (koordinata.X != 0)
            {
                if (grid[koordinata.X - 1, koordinata.Y].tipus != "tanulo")
                {
                    var coo = koordinata;
                    coo.X--;
                    korbenezes2(coo);
                }
            }
        }

        public static void tanuloKozeliKoordinatak()
        {
            var coo = new Coordinates();
            coo.X = 0;
            coo.Y = 0;
            for (int i = 0; i < 10; i++)
            {
                var e = i;
                if (finish.Y - e >= 0)
                {
                    if (grid[finish.X, finish.Y - e].tipus == "ures")
                    {
                        coo.X = finish.X;
                        coo.Y = finish.Y - e;
                        i = 10;
                    }
                }

                if (finish.X + e < grid.GetLength(0))
                {
                    if (grid[finish.X + e, finish.Y].tipus == "ures")
                    {
                        coo.X = finish.X + e;
                        coo.Y = finish.Y;
                        i = 10;
                    }
                }

                if (finish.X - e >= 0)
                {
                    if (grid[finish.X - e, finish.Y].tipus == "ures")
                    {
                        coo.X = finish.X - e;
                        coo.Y = finish.Y;
                        i = 10;
                    }
                }
            }

            if (coo.X == 0 && coo.Y == 0)
            {
                coo = finish;
            }

            finish = coo;
        }


        public static int tavolsagKalkulator(Coordinates start, Coordinates finish)
        {
            int tavolsag = Math.Abs(start.X - finish.X) + Math.Abs(start.Y - finish.Y);

            return tavolsag;
        }
    }
}