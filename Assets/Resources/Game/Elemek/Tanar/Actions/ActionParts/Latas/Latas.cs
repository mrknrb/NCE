using Resources.Kozos;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Resources.Game.Elemek.Tanar.Actions.ActionParts.Latas
{
    public class Latas
    {
        private Latoszog latoszog;
        private GameMain gameMain;
        private UpdateCaller updateCaller;
        public bool latjaAPlayert;

        public Latas(GameMain gameMain2)
        {
            gameMain = gameMain2;
            latoszog = new Latoszog(gameMain);
            updateCaller = GameObject.Find("UpdateCallerGameObject").GetComponent<UpdateCaller>();
            updateCaller.update += LatasHitLoop;
        }

        void LatasHitLoop()
        {
            if (latoszog.playerLatoszogben)
            {
               if (Physics.Linecast(gameMain.playerMain.playerHivok.Nyak.transform.position, gameMain.tanarMain.tanarHivok.szem.transform.position))
                {
                    
                   // Debug.Log("blocked");
                }
                else
                {
                    Debug.DrawLine(gameMain.playerMain.playerHivok.Nyak.transform.position, gameMain.tanarMain.tanarHivok.szem.transform.position);

                  //  Debug.Log("latja");
                }
            }
        }
    }
}