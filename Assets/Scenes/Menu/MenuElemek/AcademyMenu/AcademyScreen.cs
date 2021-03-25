using System;
using System.Collections.Generic;
using Scenes.Game.Scripts.Structs;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Menu.MenuElemek.AcademyMenu
{
    public class AcademyScreen:MonoBehaviour
    {
        public CustomGameScreen customGameScreen;
        public MonitorCanvasScreenChanger monitorCanvasScreenChanger;

        public List<Button> kuldetesek;

        private void Start()
        {
            foreach (var kuldetesButton in kuldetesek)
            {
               
                kuldetesButton.onClick.AddListener(delegate { kuldetesGombClick(kuldetesButton.name); });
            }
        }
       

        public void kuldetesGombClick(string mentesNev)
        {
           var mentes= KuldetesMentesek.MentesBetoltes(mentesNev);
           
           customGameScreen.mentesBetoltes(mentes);
           monitorCanvasScreenChanger.ChangeScreen("AcaCustom");
        }
       
        
    }
}