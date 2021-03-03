using System;
using ECASimulator.ECALibrary;
using ECASimulator.Structs;
using ECASimulator.Terem;
using UnityEngine;
using Action = System.Action;
using ECASimulator.Tanar;
using ECASimulator.UI;

namespace ECASimulator
{
    public class Main : MonoBehaviour
    {
     
        public MainMenu mainMenu;
        public ElemekGrid elemekGrid;
        public TanarMain tanar;
        public event Action update;
        public Mentes mentes;


        void Start()
        {
            mentes.sor = 10;
            mentes.oszlop = 8;
            mentes.egyhelykihagy = false;
            mentes.tanulokszama = 30;
            mentes.puskazokszama = 10;
            mentes.randomulesrend = true;
            mentes.entrance = 3;
            mentes.hatul = true;
            mentes.oldalt = true;

            //Tanar tulajdonsagok
            mentes.alertness = 7;
            mentes.sitting = 7;
            mentes.walking = 7;
            mentes.agressiveness = 7;
            mentes.eyes = 7;
            mentes.height = 7;
            
            
            

            elemekGrid = new ElemekGrid(this);

            tanar = new TanarMain(this);
            tanar.start();
        }

        public void Update()
        {
            update?.Invoke();
        }
    }
}