using System.Collections.Generic;
using Resources.Game.DataClassok;
using Resources.Game.DataClassok.PuskaMentesek;
using Resources.Game.Elemek.GridElements;
using Resources.Game.Elemek.Tanar;
using Resources.Game.Elemek.Terem;
using Resources.Kozos.Player;
using Resources.Menu.Elemek.MenuElemek.CustomGameMenu;
using UnityEngine;
using Action = System.Action;

namespace Resources.Game.Elemek
{
    public class GameMain : MonoBehaviour
    {
        public Elem[,] elemekGrid;
        private ElemekGridObject elemekGridObject;
        public TanarMain tanarMain;
        public PlayerMain playerMain;

        public Mentes mentes;

        public GameObject playerPrefab;
       
        void Start()
        {
          // mentes= CustomGameScreen.mentesModositott;
          
           //ettől menteses
           CustomGameScreen.mentesModositott=new Mentes();
           mentes = CustomGameScreen.mentesModositott;
            mentes.sor = 10;
            mentes.oszlop = 6;
            mentes.egyhelykihagy = true;
            mentes.tanulokszama = 20;
            mentes.puskazokszama = 10;
            mentes.randomulesrend = true;
            mentes.duplaPad = true;
            mentes.playerPadid = 12;


  
            var cheatSheetPrintedMentes = new CheatSheetPrintedMentes();

            cheatSheetPrintedMentes.puskaid = "puska0";
            cheatSheetPrintedMentes.tipus = PuskaTipusok.cheatSheetPrinted;
            cheatSheetPrintedMentes.begin = 1;
            cheatSheetPrintedMentes.end = 10;
            cheatSheetPrintedMentes.hasznalva = true;
            cheatSheetPrintedMentes.locked = false;
            cheatSheetPrintedMentes.rejtekhelyid = "RejtekHely5";
            cheatSheetPrintedMentes.rejtekhely2 = "dd";
            mentes.puskaMentes.Add(cheatSheetPrintedMentes);

            var phoneMentes = new TelefonPuskaMentes();

            phoneMentes.puskaid = "puska1";
            phoneMentes.tipus = PuskaTipusok.telefon;
            phoneMentes.begin = 5;
            phoneMentes.end = 20;
            phoneMentes.hasznalva = true;
            phoneMentes.locked = false;
            phoneMentes.rejtekhelyid = "RejtekHely3";
            mentes.puskaMentes.Add(phoneMentes);


            mentes.alertness = 3;
            mentes.walking = 3;
            mentes.agressiveness = 3;
            mentes.eyes = 3;

            //eddig menteses
            
            playerMain = new PlayerMain();
            playerMain.MentesBetoltes(mentes);
            
            elemekGridObject = new ElemekGridObject();
      elemekGridObject.ElemekGridFrissitesMentessel(mentes);
          //  elemekGridObject.ElemekGridFrissitesGriddel(mentes.Grid);
           
            elemekGrid = elemekGridObject.mentes.Grid;
            elemekGridObject.GeneralasGameObjectek(playerMain);


            tanarMain = new TanarMain(this);
            tanarMain.start();
        }
    }
}