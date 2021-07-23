#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

using System;
using UnityEngine;

namespace Resources.Kozos.Player
{
    public class LookWithMouse
    {
        float mouseSensitivityDefault = 200f;
        float xRotation = 0f;
        float yRotation = 0f;
        Camera cameraPlayer;
        GameObject nyak;
        float cameraFov;
        UpdateCaller updateCaller;
        
        public event Action<bool> ZoomMode;
        public event Action<bool, RaycastHit> raycastHitEventsUpdate;
        public event Action<bool> mouseButtonDown;
        public event Action<bool, RaycastHit> mouseOver;
        public event Action< RaycastHit> mouseClick;
        public event Action<bool, RaycastHit> mouseHold;
        public event Action<string> keyPressed;
        
        public LookWithMouse(Camera cameraPlayer2, GameObject nyak2)
        {
            cameraPlayer = cameraPlayer2;
            nyak = nyak2;

            Cursor.lockState = CursorLockMode.Locked;
            updateCaller = GameObject.Find("UpdateCallerGameObject").GetComponent<UpdateCaller>();

            updateCaller.update += LookAround;
            updateCaller.update += Zoom;
            updateCaller.update += RaycastGenerator;
            updateCaller.update += MouseButtonEventGenerator;
            updateCaller.update += KeyBoardButtonEventGenerator;
            raycastHitEventsUpdate += MouseOverEventGenerator;
            mouseButtonDown += MouseClickEventGenerator;
            mouseOver += MouseClickTorloseged;
            mouseButtonDown += MouseHoldEventGenerator;
            mouseOver += MouseHoldEventStop;
            mouseButtonDown += MouseHoldEventStop2;

        }

     

        private void LookAround()
        {
            var camFovOszto = cameraFov / 50;
            var mouseSensitivity = mouseSensitivityDefault * camFovOszto;
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -60f, 80f);
            yRotation -= mouseX;
            yRotation = Mathf.Clamp(yRotation, -120f, 120f);
            nyak.transform.localRotation = Quaternion.Euler(xRotation, -yRotation, 0f);
        }

        public bool ZoomModebe;

        private void Zoom()
        {
            float minFov = 15f; //kozelit
            float maxFov = 50f; //tavol
            float sensitivity = 50f;


            cameraFov = cameraPlayer.fieldOfView;
            cameraFov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            cameraFov = Mathf.Clamp(cameraFov, minFov, maxFov);
            if (cameraPlayer.fieldOfView != cameraFov)
            {
                cameraPlayer.fieldOfView = cameraFov;
            }


            if (cameraFov < 40 && !ZoomModebe)
            {
                ZoomModebe = true;
                ZoomMode?.Invoke(true);
            }
            else if (cameraFov > 39 && ZoomModebe)
            {
                ZoomModebe = false;
                ZoomMode?.Invoke(false);
            }
        }

        void RaycastGenerator()
        {
            var ray = cameraPlayer.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out var hit))
            {
                raycastHitEventsUpdate?.Invoke(true, hit);
            }
            else
            {
                raycastHitEventsUpdate?.Invoke(false, new RaycastHit());
            }
        }

        private bool mousedown;

        void MouseButtonEventGenerator()
        {
            if (mousedown && Input.GetMouseButtonUp(0))
            {
                mouseButtonDown?.Invoke(false);
                mousedown = false;
            }

            if (!mousedown && Input.GetMouseButtonDown(0))
            {
                mouseButtonDown?.Invoke(true);
                mousedown = true;
            }
        }

        private RaycastHit PreviousRayCastHit;

        public void MouseOverEventGenerator(bool sikeres, RaycastHit hit)
        {
            var raycastseg = new RaycastHit();
            if (sikeres)
            {
                if (PreviousRayCastHit.transform != hit.transform)
                {
                    if (PreviousRayCastHit.transform != raycastseg.transform)
                    {
                        mouseOver?.Invoke(false, PreviousRayCastHit);
                    }
                    mouseOver?.Invoke(true, hit);
                }
                PreviousRayCastHit = hit;
            }
            else
            {
                if (PreviousRayCastHit.transform != raycastseg.transform)
                {
                    mouseOver?.Invoke(false, PreviousRayCastHit);
                }

                PreviousRayCastHit = new RaycastHit();
            }
        }

     
        private RaycastHit ClickRaycasthit;
        private float elozoMouseDownIdoPont;
        private bool mouseHoldON;
        public void MouseClickEventGenerator(bool mousedown2)
        {
            if (mousedown2)
            {
                elozoMouseDownIdoPont = Time.time;
                ClickRaycasthit = PreviousRayCastHit;
            }
            else
            {
               var uresraycasthit=new RaycastHit();
               var elozoMouseDownHozKepestDeltaTime = Time.time - elozoMouseDownIdoPont;
                if (ClickRaycasthit.transform == PreviousRayCastHit.transform&&uresraycasthit.transform!=PreviousRayCastHit.transform&&elozoMouseDownHozKepestDeltaTime<0.3)
                {
                    mouseClick?.Invoke(PreviousRayCastHit);
                    elozoMouseDownIdoPont = 0;
                    Debug.Log(PreviousRayCastHit.transform.name);
                    ClickRaycasthit = uresraycasthit;
                }
            }
        }
        void MouseClickTorloseged(bool sikeres, RaycastHit hit)
        {
            if (!sikeres)
            {
                ClickRaycasthit=new RaycastHit();
            }
        }
        public void MouseHoldEventGenerator(bool mousedown2)
        {
            if (mousedown2)
            {
                
                elozoMouseDownIdoPont = Time.time;
                ClickRaycasthit = PreviousRayCastHit;
               updateCaller.update+= MouseHoldEventGeneratorIdomeroSegedLoop;
            }
            else
            {
               
            }
        }

        public void MouseHoldEventGeneratorIdomeroSegedLoop()
        {
            
            if (Time.time-elozoMouseDownIdoPont > 0.3&&elozoMouseDownIdoPont!=0)
            {
                updateCaller.update-= MouseHoldEventGeneratorIdomeroSegedLoop;
                mouseHoldON = true;
                    mouseHold?.Invoke(true,PreviousRayCastHit);
            }

            if (elozoMouseDownIdoPont == 0)
            {
                updateCaller.update-= MouseHoldEventGeneratorIdomeroSegedLoop;
                
            }
            
        }
        private void MouseHoldEventStop(bool enter,RaycastHit h)
        {
           
            if (!enter&&mouseHoldON)
            {
                mouseHoldON = false;
                mouseHold?.Invoke(false,PreviousRayCastHit);
                elozoMouseDownIdoPont = 0;
            }
        }
        private void MouseHoldEventStop2(bool buttondown)
        {
            if (!buttondown&&mouseHoldON)
            {
                mouseHoldON = false;
                mouseHold?.Invoke(false,PreviousRayCastHit);
                elozoMouseDownIdoPont = 0;
            }
        }

        public void ZoomMax()
        {
            cameraPlayer.fieldOfView = 15f;
        }

       void KeyBoardButtonEventGenerator()
       {
         string key=  KeyBoardGetKey.KeyPressedGenerator();
         if (key != "")
         {
             keyPressed?.Invoke(key);   
             
         }
       }
        void KeyPress()
        {
           
        }
    }
}