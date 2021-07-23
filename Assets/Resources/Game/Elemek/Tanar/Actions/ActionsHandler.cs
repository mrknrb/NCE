using System;
using System.Collections.Generic;
using Resources.Game.Elemek.Tanar.Actions.ActionsMain;
using UnityEngine;

namespace Resources.Game.Elemek.Tanar.Actions
{
    public class ActionsHandler
    {
        public List<ActionInterface> actionsList;
        private GameMain gameMain;
        private event Action actionStopEvent;

        public ActionsHandler(GameMain mainbe)
        {
            gameMain = mainbe;
            actionsList = new List<ActionInterface>();
            actionStopEvent += nextAction;
        }

        public void startActions()
        {
            if (nextActionFinder()==null)
            {
                actionsList.Add(new JarkalniAction(gameMain,actionStopEvent));
            }

            var action = nextActionFinder();
            action.startAction();
          
        }

        public void nextAction()
        {
        
             Debug.Log("ggggggg");
                startActions();
           
        }

        ActionInterface nextActionFinder()
        {
            var actionListAktualisak = new List<ActionInterface>();
            
            foreach (var action in actionsList)
            {
                if (!action.actionBefejezve)
                {
                    actionListAktualisak.Add(action);
                }
            }
            
            actionListAktualisak.Sort((x, y) => x.prioritas.CompareTo(y.prioritas));


            if (actionListAktualisak.Count == 0)
            {
                return null;
            }
            else
            {
                return actionListAktualisak[0];
            }
         
        }

        public void newAction()
        {
        }
    }
}