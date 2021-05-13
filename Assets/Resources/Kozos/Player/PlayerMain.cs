using Resources.Game.DataClassok;
using Resources.Kozos.Player.Puskazas;
using Resources.Kozos.Player.Rejtekhelyek;
using Resources.Kozos.Player.Selection;
using UnityEngine;

namespace Resources.Kozos.Player
{
    public class PlayerMain
    {
        public GameObject playerGameObject;
        private PlayerHivok playerHivok;
        private LookWithMouse lookWithMouse;
        private RejtekhelyManager rejtekhelyManager;
        private PuskazasManager puskazasManager;
        private Mentes mentes;

        public PlayerMain()
        {
            playerGameObject = GameObject.Instantiate(UnityEngine.Resources.Load("Kozos/Player/Player") as GameObject);
            playerHivok = playerGameObject.GetComponent<PlayerHivok>();
            lookWithMouse = new LookWithMouse(playerHivok.CameraPlayer, playerHivok.Nyak);
            rejtekhelyManager = new RejtekhelyManager(playerHivok, lookWithMouse);
            puskazasManager = new PuskazasManager( playerHivok);

        }

        public void MentesBetoltes(Mentes mentes2)
        {
           
            mentes = mentes2;
            puskazasManager.PuskakBetoltese(mentes);
            rejtekhelyManager.PuskakBetoltese(puskazasManager.puskaList);


        }

    }
}