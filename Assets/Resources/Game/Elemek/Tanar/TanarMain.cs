using Resources.Game.Elemek.Tanar.Actions;
using Resources.Game.Elemek.Tanar.Actions.ActionParts.Latas;
using Resources.Game.Elemek.Tanar.Actions.ActionParts.Mozgas;
using UnityEngine;

namespace Resources.Game.Elemek.Tanar
{
    public class TanarMain
    {
        public GameObject TanarObject;
        private Mozgas mozgas;
        private ActionsHandler actionsHandler;
        private GameMain gameMain;
        private Latas latas;
        public TanarHivok tanarHivok;
      
       public TanarMain(GameMain main2)
        {
            gameMain = main2;
            TanarObject = GameObject.Instantiate(UnityEngine.Resources.Load("Game/Elemek/Tanar/Tanar") as GameObject);
            tanarHivok = TanarObject.GetComponent<TanarHivok>();
        }

        public void start()
        {
          
            TanarObject.transform.Translate(1, 0, -1);
            actionsHandler = new ActionsHandler(gameMain);
            actionsHandler.startActions();
            latas=new Latas(gameMain);
        }


    }
}