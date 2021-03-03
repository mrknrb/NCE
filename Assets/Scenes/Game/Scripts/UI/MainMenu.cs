using UnityEngine;
using UnityEngine.EventSystems;

namespace ECASimulator.UI
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