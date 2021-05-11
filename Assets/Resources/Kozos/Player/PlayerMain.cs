using Resources.Kozos.Player.Rejtekhelyek;
using Resources.Kozos.Player.Selection;
using UnityEngine;

namespace Resources.Kozos.Player
{
    public class PlayerMain
    {
        private GameObject playerGameObject;
        private PlayerHivok playerHivok;
        private LookWithMouse lookWithMouse;
        private SelectionManager selectionManager;
        private RejtekhelyManager rejtekhelyManager;

       public PlayerMain()
        {
            playerGameObject = GameObject.Instantiate(UnityEngine.Resources.Load("Kozos/Player/Player") as GameObject);
            playerHivok = playerGameObject.GetComponent<PlayerHivok>();
            lookWithMouse=new LookWithMouse(playerHivok.CameraPlayer,playerHivok.Nyak);
           // selectionManager= new SelectionManager(playerHivok);
            rejtekhelyManager = new RejtekhelyManager(playerHivok,lookWithMouse);
        }
        
        
        
    }
}