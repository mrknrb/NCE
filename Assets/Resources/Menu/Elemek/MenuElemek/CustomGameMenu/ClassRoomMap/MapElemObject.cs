using System;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.Menu.Elemek.MenuElemek.CustomGameMenu.ClassRoomMap
{
    public class MapElemObject
    {
        
        public GameObject MapElemGameObject;
        public Image mapElemImage;
        public Button mapElemButton;
        public int IndexZero;
        public int IndexOne;
        public event Action<int,int> clickEvent;
        public MapElemObject(GameObject mapElemGameObject2)
        {
            MapElemGameObject = mapElemGameObject2;
            mapElemImage=MapElemGameObject.GetComponent<Image>();
            mapElemButton = MapElemGameObject.GetComponent<Button>();
            mapElemButton.onClick.AddListener(actioncallseged);

         
        }
   void actioncallseged()
            {
                clickEvent?.Invoke(IndexZero,IndexOne);
            }
       
    }
}