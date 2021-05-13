using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Resources.Kozos.Player.Rejtekhelyek
{
    public class RejtekhelyekInput
    {
        private UpdateCaller updateCaller;
        private Camera cameraMain;
        private Transform selection;
        private Transform grabstartselection;
        private bool mouseover;
        private bool mousedown;


        public event Action<string> rejtekhelyMouseOverEvent;
        public event Action rejtekhelyMouseLeaveEvent;
        public event Action<string> rejtekhelyKlikkEvent;
        public event Action<string> rejtekhelyZoomEvent;
        public event Action<string> rejtekhelyZoomCancelEvent;
        public event Action<string> rejtekhelyGrabStartEvent;
        public event Action rejtekhelyGrabCancelEvent;
        public event Action<string, string> rejtekhelyGrabToAnotherJelzesEvent;
        public event Action<string, string> rejtekhelyGrabToAnotherEvent;

        public RejtekhelyekInput(PlayerHivok playerHiv,LookWithMouse lookWithMouse)
        {
            cameraMain = playerHiv.CameraPlayer;
            updateCaller = GameObject.Find("UpdateCallerGameObject").GetComponent<UpdateCaller>();
            lookWithMouse.mouseButtonDown +=  MouseButtonEventGenerator;
           // lookWithMouse.raycastHitEventsUpdate += MouseOverLeaveEventsUpdateGenerator;
            lookWithMouse.mouseOver += MouseOver;
        }

        public void MouseOver(bool mouseover2,RaycastHit hit)
        {
            if (mouseover2)
            {
             
                if (hit.transform.CompareTag("Selectable"))
                {
                   
                        selection = hit.transform;
                        mouseover = true;
                        EventTree();
                   
                }
                else
                {
                   
                        mouseover = false;
                        EventTree();
                   
                }
            }
            else
            {
               
                    mouseover = false;
                    EventTree();
                
            }
           
        }
        public void MouseOverLeaveEventsUpdateGenerator(bool sikeres,RaycastHit hit)
        {
            if (sikeres)
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


        void MouseButtonEventGenerator(bool mousedown2)
        {
            mousedown = mousedown2;
            EventTree();
           
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
                    grabstartselection = null;
                }
                else if (mouseover && mousedown)
                {
                    if (grabstartselection != selection)
                    {
                        rejtekhelyGrabToAnotherJelzesEvent?.Invoke(grabstartselection.name, selection.name);
                        rejtekHelystates = RejtekHelyStates.grabmenu;
                    }
                }
            }
            else if (rejtekHelystates == RejtekHelyStates.grabmenu)
            {
                if (mouseover && !mousedown)
                {
                    rejtekhelyGrabToAnotherEvent?.Invoke(grabstartselection.name, selection.name);
                    rejtekHelystates = RejtekHelyStates.normalmouseover;
                    grabstartselection = null;
                }
                else if (!mouseover && mousedown)
                {
                    if (grabstartselection != selection)
                    {
                        rejtekHelystates = RejtekHelyStates.grabbing;
                    }
                }
            }
            /*
            Debug.Log("---------------------------------------");
            Debug.Log("rejtekHelystates"+rejtekHelystates);
            Debug.Log("mouseover"+mouseover);
            Debug.Log("mousedown"+mousedown);
            */
        }
    }
}