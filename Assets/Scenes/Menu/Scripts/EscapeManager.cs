using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Menu
{
    public class EscapeManager : MonoBehaviour
    {
       public List<GameObject> elsoAllapotosok;
        public List<GameObject> masodikAllapotosok;
        private bool allapotAktualis=true;
        private void Start()
        {
        }

        public void cursorLeftScreen()
        {
            GameObject monitorCanvas = GameObject.Find("MonitorCanvas");
            EventSystem.current.IsPointerOverGameObject();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (allapotAktualis)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    foreach (var gameobject in elsoAllapotosok)
                    {
                        gameobject.SetActive(false);
                    }
                    foreach (var gameobject in masodikAllapotosok)
                    {
                        gameobject.SetActive(true);
                    }
                    allapotAktualis = false;
                }
                else
                {    Cursor.lockState = CursorLockMode.None;
                    foreach (var gameobject in elsoAllapotosok)
                    {
                        gameobject.SetActive(true);
                    }
                    foreach (var gameobject in masodikAllapotosok)
                    {
                        gameobject.SetActive(false);
                    }
                    allapotAktualis = true;
                }
                Debug.Log("Escape key was pressed");
                
                
            }
            
        }
       
    }
}