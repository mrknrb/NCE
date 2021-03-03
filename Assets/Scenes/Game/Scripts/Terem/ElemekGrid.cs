using System.Collections.Generic;
using System.Linq;
using ECASimulator.Structs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ECASimulator.Terem
{
    public class ElemekGrid
    {
        private Main main;
        public Elem[,] gridElements;
        public ElemekGrid(Main main2)
        {
            main = main2;
            generalas();
        }
        private void generalas()
        {
            var mentes = this.main.mentes;

            int elemid = -1;
            int padid = -1;
            int tanuloid = -1;
            var entranceNumbers = OszlopEntranceNumbers.Generate(mentes.oszlop, mentes.entrance);

            Elem[,] grid = new Elem[osszesoszlop(mentes), osszessor(mentes)];
            var hanyadiktanulolist = hanyadiktanulo(mentes);
            var puskazok = hanyadiktanulolist.Take(mentes.puskazokszama);

            Listkevero.Shuffle(hanyadiktanulolist);
            //------------------------------------------------------------------------------------------------------------------------grid megtöltése

            for (int oszlop = 0; oszlop < grid.GetLength(0); oszlop++)
            {
                for (int sor = 0; sor < grid.GetLength(1); sor++)
                {
                    var elem = new Elem();
                    elem.tipus = "pad";
                    elem.puskazo = false;
                    elem.tanuloid = 0;
                    //-----------------------------------------------------------------------Padok generálás
                    if (sor == grid.GetLength(1) - 1 && mentes.hatul) //sor
                    {
                        elem.tipus = "ures";
                    }

                    if (sor == 0 || sor == 1 || sor == 2) //sor
                    {
                        // print("fasza");
                        elem.tipus = "ures";
                    }

                    //---------------------------------------
                    elem.tipus = elemtipusgeneralooszlop(mentes, grid.GetLength(0), entranceNumbers, oszlop, elem.tipus);

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

                    if (elem.tipus == "ures")
                    {
                        GameObject instance = GameObject.Instantiate(Resources.Load("Padlo", typeof(GameObject))) as GameObject;
                        // var instance = Instantiate(Resources.Load("Padlo", typeof(GameObject))) as GameObject;
                        instance.transform.Translate(oszlop, 0, -sor);
                        elem.gameObject = instance;
                    }

                    if (elem.tipus == "pad")
                    {
                        GameObject instance = GameObject.Instantiate(Resources.Load("Pad", typeof(GameObject))) as GameObject;


                        //   var instance = Instantiate(Resources.Load("Pad", typeof(GameObject))) as GameObject;
                        instance.transform.Translate(oszlop, 0, -sor);
                        elem.gameObject = instance;
                    }

                    if (elem.tipus == "tanulo")
                    {
                        GameObject instance = GameObject.Instantiate(Resources.Load("Tanulo", typeof(GameObject))) as GameObject;

                        //  var instance = Instantiate(Resources.Load("Tanulo", typeof(GameObject))) as GameObject;
                        instance.transform.Translate(oszlop, 0, -sor);
                        elem.gameObject = instance;
                    }

                    //---------------------tanulok és puskazok berakasa


                    //   print(elem.tipus);
                    elemid++;
                    elem.elemid = elemid;
                    elem.padid = padid;
                    elem.karma = karmagenerator(elem.puskazo);
                    grid[oszlop, sor] = elem;

                    
                    
                }
            }

            this.gridElements = grid;
        }


        private int karmagenerator(bool puskazo)
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

        private List<int> hanyadiktanulo(Mentes mentes)
        {
            int osszeshely = mentes.sor * mentes.oszlop;
            var padidlistatanulo = new List<int>();

            var padidlistacheater = new List<int>();

            void random()
            {
                for (int i = 0; i < mentes.tanulokszama; i++)
                {
                    int padid = 0;
                    random2();

                    void random2()
                    {
                        if (mentes.egyhelykihagy)
                        {
                            padid = Random.Range(0, osszeshely / 2) * 2;
                        }
                        else
                        {
                            padid = Random.Range(0, osszeshely);
                        }


                        var marvan = false;
                        foreach (var ia in padidlistatanulo)
                        {
                            if (padid == ia)
                            {
                                marvan = true;
                            }
                        }

                        if (marvan)
                        {
                            random2();
                        }
                    }

                    // print(padid);
                    padidlistatanulo.Add(padid);
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

        private string elemtipusgeneralooszlop(Mentes mentes, int osszesoszlopszam, int[] entranceNumbers, int i, string elemtipus2)
        {
            string elemtipus = elemtipus2;
            int pluszegyoszlopseged = 0;
            if (mentes.oldalt)
            {
                pluszegyoszlopseged = 1;
            }

            if (i == 0 && mentes.oldalt)
            {
                elemtipus = "ures";
            }

            if (i == osszesoszlopszam - 1 && mentes.oldalt)
            {
                elemtipus = "ures";
            }

            foreach (var entranceNumber in entranceNumbers)
            {
                if (i == entranceNumber + pluszegyoszlopseged)
                {
                    elemtipus = "ures";
                }
            }

            return elemtipus;
        }

        private int osszesoszlop(Mentes mentes)
        {
            int oldaloszlop = 0;
            if (mentes.oldalt)
            {
                oldaloszlop = 2;
            }

            var osszesoszlop = mentes.oszlop + mentes.entrance + oldaloszlop;
            return osszesoszlop;
        }

        private int osszessor(Mentes mentes)
        {
            int hatulsor = 0;
            if (mentes.hatul )
            {
                hatulsor = 1;
            }

            var osszessor = mentes.sor + hatulsor + 3;

            return osszessor;
        }
    }
}