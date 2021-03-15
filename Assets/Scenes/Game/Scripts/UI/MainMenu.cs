using UnityEngine;

namespace Scenes.Game.Scripts.UI
{
 
    public class MainMenu
    {
        public GameObject canvas;

       public MainMenu()
        {
            canvas = GameObject.Find("MonitorCanvas");
           
        }
        
        
    }
}