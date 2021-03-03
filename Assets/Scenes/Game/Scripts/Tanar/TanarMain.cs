using System.Collections;
using System.Threading.Tasks;
using ECASimulator.Structs;
using ECASimulator.Tanar.ActionParts;
using UnityEditor;
using UnityEngine;

namespace ECASimulator.Tanar
{
    public class TanarMain
    {
        private Mozgas mozgas;
        private ActionsHandler actionsHandler;
        private Main main;
        public GameObject tanarObject;

        public TanarMain(Main main2)
        {
            main = main2;

            tanarObject = GameObject.Instantiate(Resources.Load("Tanar", typeof(GameObject))) as GameObject;

            tanarObject.transform.Translate(1, 0, -1);

            actionsHandler=new ActionsHandler(main);
            
           
            
         
            
        }

        public void start()
        {
            actionsHandler.startActions();

        }



        private void ExampleCoroutine()
        {
        }
    }
}