using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
   [SerializeField] private Camera camera;
    private Transform _selection;
    private GameObject instance;
  
    private void Start()
    {
        
    }

    private void Update()
    {
      

        var ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
          
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            
            var selection = hit.transform;
          
            if (selection.CompareTag(selectableTag))
            {
                if (Input.GetMouseButton(0))
                {
                    selection.gameObject.GetComponent<Button>().onClick.Invoke();
                }

                instance.transform.localScale = hit.collider.bounds.size*1.5f;
                
                instance?.SetActive(true);
                instance.transform.position = hit.collider.bounds.center;
              
                _selection = selection;
            }
        }
    }
}