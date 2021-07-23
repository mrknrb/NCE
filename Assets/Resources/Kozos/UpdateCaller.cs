using System;
using UnityEngine;

namespace Resources.Kozos
{
    public class UpdateCaller : MonoBehaviour {
        
        public event Action update;
        
        private void Update()
        {
            update?.Invoke();
        }
        
        
        /*
        private static UpdateCaller instance;
        public static void AddUpdateCallback(Action updateMethod) {
            if (instance == null) {
                instance = new GameObject("[Update Caller]").AddComponent<UpdateCaller>();
            }
            instance.updateCallback += updateMethod;
        }
 
        private Action updateCallback;
 
        private void Update() {
            updateCallback();
        }
        */
        
        
        
    }
}