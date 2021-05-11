using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Resources.Kozos.Player.Rejtekhelyek
{
    public class RejtekhelyekInput
    {
        private List<GameObject> rejtekHelyGameObject;
        private UpdateCaller updateCaller;
        private Camera cameraMain;
        private GameObject instance;


        public RejtekhelyekInput(PlayerHivok playerHiv)
        {
            cameraMain = playerHiv.CameraPlayer;
            updateCaller = GameObject.Find("UpdateCallerGameObject").GetComponent<UpdateCaller>();
            rejtekHelyGameObject = playerHiv.RejtekhelyHivok;
            updateCaller.update += raycasting;
        }

      

      

        private Transform selection;
        private bool mouseButtonHold;
        private string mouseButtonDownRejtekHely;
        public event Action<string> rejtekhelyMouseOverEvent;
        public event Action rejtekhelyMouseLeaveEvent;
        public event Action<string> rejtekhelyKlikkEvent;
        public event Action<string> rejtekhelyZoomEvent;
        public event Action<string> rejtekhelyZoomCancelEvent;
        public event Action<string> rejtekhelyGrabStartEvent;
        public event Action rejtekhelyGrabCancelEvent;
        public event Action<string,string> rejtekhelyGrabToAnotherEvent;
        void raycasting()
        {

            var ray = cameraMain.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.transform.CompareTag("Selectable"))
                {
                    rejtekhelyMouseOverEvent?.Invoke(hit.transform.name);
                    if (Input.GetMouseButtonDown(0))
                    {
                        mouseButtonHold = true;
                        mouseButtonDownRejtekHely = hit.transform.name;
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        mouseButtonHold = false;
                        if (hit.transform.name==mouseButtonDownRejtekHely)
                        {
                            rejtekhelyKlikkEvent?.Invoke(hit.transform.name);
                        }
                        else
                        {
                            rejtekhelyGrabToAnotherEvent?.Invoke(mouseButtonDownRejtekHely, hit.transform.name);
                        }
                      
                      
                        
                    }
                }
                else
                {
                    rejtekhelyMouseLeaveEvent?.Invoke();
                    if (mouseButtonHold)
                    {
                        rejtekhelyGrabStartEvent?.Invoke(mouseButtonDownRejtekHely);
                        //      uiKezeloMain.nyilGrabbing(selection.position);
                    }
                    else
                    {
                     rejtekhelyGrabCancelEvent?.Invoke();
                 //       uiKezeloMain.nyilGrabbingVege();
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                mouseButtonHold = false;
            }
        }


    }
}