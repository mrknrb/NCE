using System;
using Resources.Kozos;
using UnityEngine;

namespace Resources.Game.Elemek.Tanar.Actions.ActionParts.Latas
{
    public class Latoszog
    {
        private UpdateCaller updateCaller;
        private GameMain gameMain;
        public bool playerLatoszogben;

        public Latoszog(GameMain gameMain2)
        {
            gameMain = gameMain2;
            updateCaller = GameObject.Find("UpdateCallerGameObject").GetComponent<UpdateCaller>();
            updateCaller.update += playerTanarLatoszogGeneralo;
        }

        void playerTanarLatoszogGeneralo()
        {
          
            //x es z tengely a position es y a rotation
            var playerposition = gameMain.playerMain.playerGameObject.transform.position;
            var tanarposition = gameMain.tanarMain.TanarObject.transform.position;
            var tanarrotation = gameMain.tanarMain.TanarObject.transform.eulerAngles.y;


            var playerpositionVector2 = new Vector2(playerposition.x, playerposition.z);
            var tanarpositionVector2 = new Vector2(tanarposition.x, tanarposition.z);


            if (Vector2.Distance(playerpositionVector2, tanarpositionVector2) < 100)
            {
                var angleKettoKozott = NCELibrary.FindDegree( playerpositionVector2 , tanarpositionVector2);
                if (Math.Abs(angleKettoKozott - tanarrotation) < 45)
                {
                 //  Debug.Log("Lattttt");
                    playerLatoszogben = true;
                }
                else
                {
                    playerLatoszogben = false;
                }
               // Debug.Log(tanarrotation);   
              //  Debug.Log(angleKettoKozott);
            }
            else
            {
                playerLatoszogben = false;
            }
        }


       
    }
}