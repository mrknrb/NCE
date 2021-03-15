using System.Collections.Generic;
using Scenes.Game.Scripts.Tanar.Actions;

namespace Scenes.Game.Scripts.Tanar
{
    public class ActionsHandler
    {
        public List<ActionInterface>  actionsList;
        private Main main;

        public ActionsHandler(Main mainbe)
        {
            main = mainbe;
            actionsList=new List<ActionInterface>();
           
        }

        public void startActions()
        {
            if (actionsList?.Count == 0)
            {
                actionsList.Add(new JarkalniAction(main));
            }

            actionsList?[0].startAction();
            if (actionsList.Count != 0)
            {
                
                actionsList[0].actionVege += nextAction;
            }
        }

        public void nextAction(bool sikeres)
        {
            if (sikeres)
            {
                actionsList.Remove(actionsList[0]);
                startActions();
            }
        }
        public void newAction()
        {
        
        }
    }
}