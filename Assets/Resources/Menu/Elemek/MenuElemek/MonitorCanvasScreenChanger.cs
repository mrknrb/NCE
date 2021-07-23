using System.Collections.Generic;
using UnityEngine;

namespace Resources.Menu.Elemek.MenuElemek
{
    public class MonitorCanvasScreenChanger : MonoBehaviour
    {
        public List<GameObject> Screens;

   

        public void ChangeScreen(GameObject Activatable)
        {
            foreach (var Screen in Screens)
            {
                Screen.SetActive(false);
            }
            Activatable.SetActive(true);
        }
    }
}