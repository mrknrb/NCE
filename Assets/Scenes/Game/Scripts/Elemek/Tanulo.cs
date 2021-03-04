using ECASimulator.Structs;
using UnityEngine;

namespace ECASimulator.Elemek
{
    public class Tanulo:MonoBehaviour
    {
       
        public Elem GridElem;
            private void Start()
            {
               Debug.Log(GridElem.elemid); 
            }

            private void Update()
            {
              
            }
     
    }
}