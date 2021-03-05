using System.Collections.Generic;
using System.Linq;
using ECASimulator.Elemek;
using ECASimulator.Structs;
using ICSharpCode.NRefactory.PrettyPrinter;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ECASimulator.Terem
{
    public class ElemekGridClass
    {
        private Mentes mentes;
        public Elem[,] gridElements;

        public ElemekGridClass(Mentes mentes)
        {
            this.mentes = mentes;
            generalas();
        }

        private void generalas()
        {
            var mentes = this.mentes;
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
                   
                    grid[oszlop,sor ] = elem;
                }
            }

            this.gridElements = grid;
        }

        public void GeneralasGameObjectek()
        { for (int oszlop = 0; oszlop < this.gridElements.GetLength(0); oszlop++)
                         {
            for (int sor = 0; sor < this.gridElements.GetLength(1); sor++)
            {
               
                    var elem = this.gridElements[oszlop,sor ];
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
            //visszadob annyi padid-t, amennyi tanulo van a mentesi beallitasok szerint
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

        private int[] oszlopEntranceNumbersGenerator(int oszlopszam, bool duplapadok)
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


        private int osszesoszlop(Mentes mentes)
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

        private int osszessor(Mentes mentes)
        {
            var osszessor = mentes.sor + 3 + 1;
            return osszessor;
        }
    }
}