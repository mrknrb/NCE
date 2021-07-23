using System.Collections.Generic;
using Resources.Menu.Elemek.MenuElemek.CustomGameMenu;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.Menu.Elemek.MenuElemek.AcademyMenu
{
    public class AcademyScreen : MonoBehaviour
    {
        public CustomGameScreen customGameScreen;
        public MonitorCanvasScreenChanger monitorCanvasScreenChanger;
        public GameObject customGameScreenGameObject;
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
            var mentes = KuldetesMentesek.MentesBetoltes(mentesNev);

            customGameScreen.mentesBetoltes(mentes);
            monitorCanvasScreenChanger.ChangeScreen(customGameScreenGameObject);
        }
    }
}