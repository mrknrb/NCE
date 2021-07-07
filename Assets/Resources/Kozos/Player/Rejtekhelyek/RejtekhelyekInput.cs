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
        private RejtekhelyManager rejtekhelyManager;
       
        private Transform mouseOverSelection;
        private Transform grabStartSelection;
        private Transform grabFinishSelection;
        private bool mouseover;
        private bool mousedown;
        private string KeyDown;

        

        public RejtekhelyekInput(PlayerHivok playerHiv, LookWithMouse lookWithMouse,RejtekhelyManager rejtekhelyManager2)
        {
            rejtekhelyManager = rejtekhelyManager2;
            cameraMain = playerHiv.CameraPlayer;
            updateCaller = GameObject.Find("UpdateCallerGameObject").GetComponent<UpdateCaller>();
            lookWithMouse.mouseButtonDown += MouseButtonEventGenerator;
            lookWithMouse.mouseOver += MouseOver;
            lookWithMouse.keyPressed += KeyEventGenerator;
            
        }

        public void MouseOver(bool mouseover2, RaycastHit hit)
        {
            if (mouseover2)
            {
                if (hit.transform.CompareTag("Selectable"))
                {
                    mouseOverSelection = hit.transform;
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


        void MouseButtonEventGenerator(bool mousedown2)
        {
            mousedown = mousedown2;
            EventTree();
        }
        void KeyEventGenerator(string Key)
        {
           
            KeyDown = Key;
            EventTree();
        }

        private RejtekHelyStates rejtekHelystates;

        void EventTree()
        {
            if (rejtekHelystates == RejtekHelyStates.semmi)
            {
                grabFinishSelection = null;
                grabStartSelection = null;
                rejtekhelyManager.zoomModeBekapcsBlock = false;
                if (mouseover)
                {
                    rejtekHelystates = RejtekHelyStates.normalmouseover;
                  
              
                }
            }
            else if (rejtekHelystates == RejtekHelyStates.normalmouseover)
            {
                if (!mouseover)
                {
                   
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
                   
                    rejtekhelyManager.RejtekHelyMegnyit(mouseOverSelection.name);
                    rejtekHelystates = RejtekHelyStates.semmi;
                }
                else if (!mouseover && mousedown)
                {
                    rejtekhelyManager.zoomModeBekapcsBlock = true;
                    rejtekhelyManager.rejtekhelyGrabbing(mouseOverSelection.name);
                    grabStartSelection = mouseOverSelection;
                    rejtekHelystates = RejtekHelyStates.grabbingArrow;
                }
            }
            else if (rejtekHelystates == RejtekHelyStates.grabbingArrow)
            {
                if (!mouseover && !mousedown)
                {
                    rejtekhelyManager.rejtekhelyGrabbingCancel();
                    rejtekHelystates = RejtekHelyStates.semmi;
                    grabStartSelection = null;
                }
                else if (mouseover && mousedown)
                {
                    if (grabStartSelection != mouseOverSelection)
                    {
                      
                        rejtekhelyManager.rejtekhelyGrabToAnotherJelzesStart(grabStartSelection.name, mouseOverSelection.name);
                        rejtekHelystates = RejtekHelyStates.grabArrowTo;
                    }
                }
            }
            else if (rejtekHelystates == RejtekHelyStates.grabArrowTo)
            {
                
                if (mouseover && !mousedown)
                {
                   
                    rejtekhelyManager.rejtekhelyGrabToAnotherMenu(true);
                    rejtekHelystates = RejtekHelyStates.grabbingMenu;
                    grabFinishSelection = mouseOverSelection;
                    EventTree();
                }
                else if (!mouseover && mousedown)
                {
                    if (grabStartSelection != mouseOverSelection)
                    {
                        rejtekHelystates = RejtekHelyStates.grabbingArrow;

                        rejtekhelyManager.rejtekhelyGrabToAnotherJelzesEnd();
                        rejtekhelyManager.rejtekhelyGrabbing(grabStartSelection.name);
                        EventTree();
                    }
                }
            }
            else if (rejtekHelystates == RejtekHelyStates.grabbingMenu)
            {
                rejtekhelyManager.GrabbingMenuRejtekHelyekAktival(grabStartSelection.name, grabFinishSelection.name);
                
               
                if (mousedown||KeyDown=="Space")
                {
                    
                    
                    KeyDown = "";
                    rejtekHelystates = RejtekHelyStates.normalmouseover;
                 
                 rejtekhelyManager.rejtekhelyGrabbingCancel();

                 rejtekhelyManager.rejtekhelyGrabToAnotherMenu(false);
                    grabStartSelection = null;
                    EventTree();
                }
                else if (KeyDown=="Return")
                {
                    
                   
                    rejtekhelyManager.rejtekhelyPuskaGrabToAnother(grabStartSelection.name, grabFinishSelection.name);
                    rejtekHelystates = RejtekHelyStates.normalmouseover;
                    grabStartSelection = null;
                    EventTree();
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