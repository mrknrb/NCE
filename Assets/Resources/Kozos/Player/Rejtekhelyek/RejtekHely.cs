using System;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.Kozos.Player.Rejtekhelyek
{
    public class RejtekHely
    {
        public GameObject rejtekHelyGameObject;
        public GameObject rejtekHelyJelGameObject;
        public Image rejtekHelyJelImage;
        public string rejtekHelyName;
        public string  puskaid;
        private PlayerHivok playerHivok;
        private UpdateCaller updateCaller;
        private LookWithMouse lookWithMouse;

        public RejtekHely(int i, PlayerHivok playerHivok2, RejtekhelyekInput rejtekhelyekInput, LookWithMouse lookWithMouse2)
        {
            updateCaller = GameObject.Find("UpdateCallerGameObject").GetComponent<UpdateCaller>();
            playerHivok = playerHivok2;
            rejtekHelyGameObject = playerHivok2.RejtekhelyHivok[i];
            rejtekHelyJelGameObject = playerHivok2.RejtekhelyJelHivok[i];
            rejtekHelyJelImage=rejtekHelyJelGameObject.GetComponent<Image>();
            rejtekHelyName = rejtekHelyGameObject.transform.name;
            updateCaller.update += RejtekHelyJelMozgas;
            lookWithMouse = lookWithMouse2;
            lookWithMouse.ZoomModeOn += RejtekhelyZoomModeOn;
            lookWithMouse.ZoomModeOff += RejtekhelyZoomModeOff;
        }

        void RejtekhelyZoomModeOn()
        {
            rejtekHelyGameObject.SetActive(false);
            rejtekHelyJelGameObject.SetActive(false);
        }

        void RejtekhelyZoomModeOff()
        {
            rejtekHelyGameObject.SetActive(true);
            rejtekHelyJelGameObject.SetActive(true);
        }

        void RejtekHelyJelMozgas()
        {
            rejtekHelyJelGameObject.transform.position = playerHivok.CameraPlayer.WorldToScreenPoint(rejtekHelyGameObject.transform.position);
        }
    
        
    }
}