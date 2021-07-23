using System;
using System.Collections.Generic;
using Resources.Game.DataClassok;
using Resources.Game.Elemek.GridElements;
using Resources.Kozos;
using UnityEngine;

namespace Resources.Game.Elemek.Tanar.Actions.ActionParts.Mozgas
{
    public class Mozgas
    {
        private List<Coordinates> ListOfCoordinates;
        private Elem[,] elemekGrid;
        private GameMain gameMain;
        public event Action<bool> mozgasVege;
        private GameObject tanarGameObject;
        private Coordinates finishCoordinata;
        private UpdateCaller updateCaller;

        public Mozgas(GameMain main2)
        {
            gameMain = main2;
            elemekGrid = gameMain.elemekGrid;
            tanarGameObject = gameMain.tanarMain.TanarObject;
            updateCaller = GameObject.Find("UpdateCallerGameObject").GetComponent<UpdateCaller>();
        }

        public void mozgasStop()
        {
            // main.update -= MozgasVhovaLoop;
            updateCaller.update -= MozgasVhovaLoop;
            ListOfCoordinates?.Clear();
        }

        public void ujCelpont(Coordinates finishCoordinatabe)
        {
            mozgasStop();

            ListOfCoordinates = PathFinding.findPath(elemekGrid, aktualisPozicio(), finishCoordinatabe);
            finishCoordinata = ListOfCoordinates[ListOfCoordinates.Count - 1];
            updateCaller.update += MozgasVhovaLoop;
            // main.update += MozgasVhovaLoop;
        }

        private Coordinates aktualisPozicio()
        {
            var coo = new Coordinates();
            coo.X = (int) Math.Round(tanarGameObject.transform.position.x);
            coo.Y = (int) Math.Round(-tanarGameObject.transform.position.z);
            return coo;
        }

        private void MozgasVhovaLoop()
        {
            if (ListOfCoordinates.Count != 0)
            {
                float step = 1 * Time.deltaTime; // calculate distance to move
                var pos = new Vector3();
                pos.x = ListOfCoordinates[0].X;
                pos.y = 0;
                pos.z = -ListOfCoordinates[0].Y;
                tanarGameObject.transform.position = Vector3.MoveTowards(tanarGameObject.transform.position, pos, step);
                forgasMozgasIranyaba(pos, tanarGameObject.transform.position);

                if (Vector3.Distance(tanarGameObject.transform.position, pos) < 0.001f)
                {
                    ListOfCoordinates.RemoveAt(0);
                }
            }
            else
            {
                mozgasVege?.Invoke(finishCoordinata.X == aktualisPozicio().X && finishCoordinata.Y == aktualisPozicio().Y);
                updateCaller.update -= MozgasVhovaLoop;
            }
        }

        void forgasMozgasIranyaba(Vector3 celPosition, Vector3 aktualisPosition)
        {
            var celPositionVector2 = new Vector2(celPosition.x, celPosition.z);
            var aktualisPositionVector2 = new Vector2(aktualisPosition.x, aktualisPosition.z);
            if (aktualisPositionVector2 != celPositionVector2)
            {
                var degree = NCELibrary.FindDegree(celPositionVector2, aktualisPositionVector2);
                // Debug.Log(degree);
                tanarGameObject.transform.rotation = Quaternion.Euler(0, degree, 0);
            }
        }

        private List<Vector2> lekerekitettPath(List<Coordinates> OriginalPath)
        {
            //azert vektoros, mert a coordinates int-es es azert, mert pl arraybol szed ki adatokat, szoval at kell alakitani
            var lekerekitettPath = new List<Vector2>();
            bool kovetkezoKihagyasa;
            for (int i = 0; i < OriginalPath.Count; i++)
            {
                var XKulonbseg = OriginalPath[i].X - OriginalPath[i + 2].X;
                var YKulonbseg = OriginalPath[i].Y - OriginalPath[i + 2].Y;
                if (XKulonbseg != 0 && YKulonbseg != 0)
                {
                    //kanyar volt
                    kovetkezoKihagyasa = true;
                    
                    
                    
                }
                else
                {
                    kovetkezoKihagyasa = false;
                }


                if (!kovetkezoKihagyasa)
                {
                    lekerekitettPath.Add(CooToVector(OriginalPath[i]));
                }
            }

            return lekerekitettPath;
        }

        private Vector2 CooToVector(Coordinates Coo)
        {
            var vector=new Vector2();
            vector.x = Coo.X;
            vector.y = Coo.Y;
            return vector;
        }
    
    }
}