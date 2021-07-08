using Resources.Game.DataClassok;
using Resources.Game.Elemek.GridElements;
using Resources.Game.Elemek.Terem;
using UnityEngine;

namespace Resources.Menu.Elemek.MenuElemek.CustomGameMenu.ClassRoomMap
{
    public class ClassRoomMapObject
    {
        private ClassRoomMap classRoomMapHivok;
        public ElemekGridObject elemekGridObject;
        public MapElemObject[,] mapElemGrid;
        private static Mentes mentes;

        public ClassRoomMapObject()
        {
           
            elemekGridObject = new ElemekGridObject();
             mentes = CustomGameScreen.mentesModositott;
            elemekGridObject.ElemekGridFrissitesMentessel(mentes);
            classRoomMapHivok = GameObject.Find("ClassRoomMap").GetComponent<ClassRoomMap>();
        }

        public void frissitMentessel(Mentes mentes2)

        {
            mentes = mentes2;
            foreach (Transform child in classRoomMapHivok.mapPanel.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            if (mentes.egyhelykihagy)
            {
                if (((mentes.sor * mentes.oszlop) / 2 >= mentes.tanulokszama))
                {
                   // elemekGridObject = new ElemekGridObject();
                    elemekGridObject.ElemekGridFrissitesMentessel(mentes2);
                    frissitGriddel(elemekGridObject.mentes.Grid);
                }
            }
            else
            {
                if ((mentes.sor * mentes.oszlop) >= mentes.tanulokszama)
                {
                   // elemekGridObject = new ElemekGridObject();
                    elemekGridObject.ElemekGridFrissitesMentessel(mentes2);
                    frissitGriddel(elemekGridObject.mentes.Grid);
                }
            }
        }

        void frissitGriddel(Elem[,] elemekGrid2)
        {
            //elemekGridObject = new ElemekGridObject();
            elemekGridObject.ElemekGridFrissitesGriddel(elemekGrid2);
            mapElemGrid = new MapElemObject[elemekGridObject.mentes.Grid.GetLength(0), elemekGridObject.mentes.Grid.GetLength(1)];
            for (int sor = 0; sor < elemekGridObject.mentes.Grid.GetLength(1); sor++)
            {
                GameObject mapSor = GameObject.Instantiate(classRoomMapHivok.mapSorPrefab);

                mapSor.transform.SetParent(classRoomMapHivok.mapPanel.transform);
                for (int oszlop = 0; oszlop < elemekGridObject.mentes.Grid.GetLength(0); oszlop++)
                {
                    var elem = elemekGridObject.mentes.Grid[oszlop, sor];

                    GameObject mapElemGameObject = GameObject.Instantiate(classRoomMapHivok.mapElemPrefab);
                    var mapElemObject = new MapElemObject(mapElemGameObject);
                    mapElemObject.clickEvent += ujPlayerPositionClick;
                    mapElemObject.IndexZero = oszlop;
                    mapElemObject.IndexOne = sor;
                    mapElemGrid[oszlop, sor] = mapElemObject;

                    mapElemObject.MapElemGameObject.transform.SetParent(mapSor.transform);
                    if (elem.tipus ==null)
                    {
                        mapElemObject.mapElemImage.sprite = classRoomMapHivok.nullImage;
                    }
                    if (elem.tipus == "ures")
                    {
                        mapElemObject.mapElemImage.sprite = classRoomMapHivok.uresImage;
                    }

                    if (elem.tipus == "pad")
                    {
                        mapElemObject.mapElemImage.sprite = classRoomMapHivok.padImage;
                    }

                    if (elem.tipus == "tanulo")
                    {
                        if (elem.tanuloElem.player)
                        {
                            mapElemObject.mapElemImage.sprite = classRoomMapHivok.playerImage;
                        }
                        else if (elem.tanuloElem.puskazo)
                        {
                            mapElemObject.mapElemImage.sprite = classRoomMapHivok.cheaterImage;
                        }
                        else
                        {
                            mapElemObject.mapElemImage.sprite = classRoomMapHivok.tanuloImage;
                        }
                    }
                }
            }
        }

        void frissitAlap()
        {
            foreach (Transform child in classRoomMapHivok.mapPanel.transform)
            {
                GameObject.Destroy(child.gameObject);
            }

            frissitGriddel(elemekGridObject.mentes.Grid);
        }

        void ujPlayerPositionClick(int IndexZero, int IndexOne)
        {
            var elemClicked = elemekGridObject.mentes.Grid[IndexZero, IndexOne];
            Debug.Log(elemClicked.tipus);
            if (elemClicked.tipus != "ures")
            {
                elemekGridObject.playerBerakasORAtrakasKlikk(elemClicked.padid);
                frissitAlap();
            }
        }
    }
}