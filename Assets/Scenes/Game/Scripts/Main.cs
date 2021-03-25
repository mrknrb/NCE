using Scenes.Game.Scripts.Elemek;
using Scenes.Game.Scripts.Structs;
using Scenes.Game.Scripts.Tanar;
using Scenes.Game.Scripts.Terem;
using Scenes.Game.Scripts.UI;
using UnityEngine;
using UnityEngine.Serialization;
using Action = System.Action;

namespace Scenes.Game.Scripts
{
    public class Main : MonoBehaviour
    {
     
        public MainMenu mainMenu;
        public Elem[,] elemekGrid;
        public TanarMain tanar;
        public event Action update;
        public Mentes mentes;


        void Start()
        {
           
            //elemekgrid2
            mentes.sor = 10;
            mentes.oszlop = 6;
            mentes.egyhelykihagy = true;
            mentes.tanulokszama = 20;
            mentes.puskazokszama = 10;
            mentes.randomulesrend = true;
            mentes.duplaPad = true;
            mentes.playerPadid = 10;
            //Tanar tulajdonsagok
            mentes.alertness = 3;
            mentes.walking = 3;
            mentes.agressiveness = 3;
            mentes.eyes = 3;
            

            elemekGrid =  ElemekGridGenerator.generalas(this.mentes);
        
            elemekGrid= ElemekGridGenerator.GeneralasGameObjectek(elemekGrid);
            tanar = new TanarMain(this);
            tanar.start();
        }

        public void Update()
        {
            update?.Invoke();
        }
    }
}