using System.Collections.Generic;
using UnityEngine;

namespace Resources.Kozos.Player.Puskazas.PuskazasiModszerek.TelefonPuska.TelefonUI
{
    public class TelefonScreenScript
    {
        private LookWithMouse lookWithMouse;
        private TelefonHivok telefonHivok;
        private Dictionary<string,RectTransform> AppLista;
     

        public TelefonScreenScript(LookWithMouse lookWithMouse2, TelefonHivok telefonHivok2)
        {
            lookWithMouse = lookWithMouse2;
            lookWithMouse.mouseClick += ClickEvent;
            telefonHivok = telefonHivok2;
            AppLista=new Dictionary<string, RectTransform>();
            AppLista.Add(telefonHivok.TelefonDocumentApp.name,telefonHivok.TelefonDocumentApp);
            AppLista.Add(telefonHivok.TelefonMainMenu.name,telefonHivok.TelefonMainMenu);
            AppLista.Add(telefonHivok.AloudReaderApp.name,telefonHivok.AloudReaderApp);
        }

        void OpenApp(string AppName)
        {
            foreach (var App in AppLista)
            {
                App.Value.gameObject.SetActive(false);
            }
            AppLista[AppName].gameObject.SetActive(true);
        }

        void ClickEvent(RaycastHit hit)
        {
          if(lookWithMouse.ZoomModebe)
          {
              if (AppLista.ContainsKey(hit.transform.name))
              {
                  OpenApp(hit.transform.name);
              }
          }
        }
    }
}