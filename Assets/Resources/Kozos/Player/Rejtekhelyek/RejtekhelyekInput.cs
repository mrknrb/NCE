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
            // updateCaller.update += raycasting;
            updateCaller.update += GeneratorLoop;
        }


        private Transform selection;
        private Transform grabstartselection;
        private bool mouseover;

        void GeneratorLoop()
        {
            MouseButtonEventGenerator();
            MouseOverLeaveEventGenerator();
        }
        
        
        public void MouseOverLeaveEventGenerator()
        {
            var ray = cameraMain.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.transform.CompareTag("Selectable"))
                {
                    if (!mouseover)
                    {
                        selection = hit.transform;
                        mouseover = true;
                        EventTree();
                    }
                }
                else
                {
                    if (mouseover)
                    {
                        mouseover = false;
                        EventTree();
                    }
                }
                
            }
            else
            {
                if (mouseover)
                {
                    mouseover = false;
                    EventTree();
                }
            }
        }

        private bool mousedown;

        void MouseButtonEventGenerator()
        {
            if (mousedown && Input.GetMouseButtonUp(0))
            {
                mousedown = false;
                EventTree();
            }

            if (!mousedown && Input.GetMouseButtonDown(0))
            {
                mousedown = true;
                EventTree();
            }
        }


        private RejtekHelyStates rejtekHelystates;

        void EventTree()
        {
            if (rejtekHelystates == RejtekHelyStates.semmi)
            {
                if (mouseover)
                {
                    rejtekHelystates = RejtekHelyStates.normalmouseover;
                    rejtekhelyMouseOverEvent?.Invoke(selection.name);
                }
            }
            else if (rejtekHelystates == RejtekHelyStates.normalmouseover)
            {
                if (!mouseover)
                {
                    rejtekhelyMouseLeaveEvent?.Invoke();
                    rejtekHelystates = RejtekHelyStates.semmi;
                }
                else if (mouseover && mousedown)
                {
                    rejtekHelystates = RejtekHelyStates.normalmousedown;
                }
            }
            else if (rejtekHelystates == RejtekHelyStates.normalmousedown)
            {
                if (mouseover && !mousedown)
                {
                    rejtekhelyKlikkEvent?.Invoke(selection.name);
                    rejtekHelystates = RejtekHelyStates.semmi;
                }
                else if (!mouseover && mousedown)
                {
                    rejtekhelyGrabStartEvent?.Invoke(selection.name);
                    grabstartselection = selection;
                    rejtekHelystates = RejtekHelyStates.grabbing;
                }
            }
            else if (rejtekHelystates == RejtekHelyStates.grabbing)
            {
                if (!mouseover && !mousedown)
                {
                    rejtekhelyGrabCancelEvent?.Invoke();
                    rejtekHelystates = RejtekHelyStates.semmi;
                }
                else if (mouseover && mousedown)
                {
                    if (grabstartselection != selection)
                    {
                        rejtekhelyGrabToAnotherJelzesEvent?.Invoke(grabstartselection.name, selection.name);
                        rejtekHelystates = RejtekHelyStates.grabmenu;
                    }
                }
            }else if (rejtekHelystates == RejtekHelyStates.grabmenu)
            {
                if (mouseover && !mousedown)
                {
                    rejtekhelyGrabToAnotherEvent?.Invoke(grabstartselection.name, selection.name);
                    rejtekHelystates = RejtekHelyStates.semmi;
                }
                else if (!mouseover && mousedown)
                {
                    if (grabstartselection != selection)
                    {
                        rejtekHelystates = RejtekHelyStates.grabbing;
                    }
                }
            }
        }


        private bool mouseButtonHold;
        private string mouseButtonDownRejtekHely;
        public event Action<string> rejtekhelyMouseOverEvent;
        public event Action rejtekhelyMouseLeaveEvent;
        public event Action<string> rejtekhelyKlikkEvent;
        public event Action<string> rejtekhelyZoomEvent;
        public event Action<string> rejtekhelyZoomCancelEvent;
        public event Action<string> rejtekhelyGrabStartEvent;
        public event Action rejtekhelyGrabCancelEvent;
        public event Action<string, string> rejtekhelyGrabToAnotherJelzesEvent;
        public event Action<string, string> rejtekhelyGrabToAnotherEvent;
        private bool grabbing;


        void raycasting()
        {
            var ray = cameraMain.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.transform.CompareTag("Selectable"))
                {
                    if (mouseButtonDownRejtekHely != hit.transform.name)
                    {
                        rejtekhelyMouseLeaveEvent?.Invoke();
                    }

                    if (!mouseover)
                    {
                        mouseover = true;
                        rejtekhelyMouseOverEvent?.Invoke(hit.transform.name);
                    }


                    if (Input.GetMouseButtonDown(0))
                    {
                        mouseButtonHold = true;
                        mouseButtonDownRejtekHely = hit.transform.name;
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        mouseButtonHold = false;
                        if (hit.transform.name == mouseButtonDownRejtekHely)
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
                    if (!grabbing)
                    {
                        rejtekhelyMouseLeaveEvent?.Invoke();
                        if (mouseButtonHold)
                        {
                            rejtekhelyGrabStartEvent?.Invoke(mouseButtonDownRejtekHely);
                        }
                        else
                        {
                            rejtekhelyGrabCancelEvent?.Invoke();
                        }
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