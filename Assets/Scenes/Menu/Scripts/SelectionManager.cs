using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Scenes.Menu.Scripts
{
    public class SelectionManager : MonoBehaviour
    {
        [SerializeField] private string selectableTag = "Selectable";
        [SerializeField] private Camera cameraMain;
        private Transform selection;
        private GameObject instance;
        public Image Kezelo;
        private KezeloScript kezeloScript;
        private bool mouseButtonHold;
        public Image Nyil;


        private void Start()
        {
            kezeloScript = Kezelo.GetComponent<KezeloScript>();
        }
        private void Update()
        {
            var ray = cameraMain.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(ray, out var hit))
            {
                if (hit.transform.CompareTag(selectableTag))
                {
                    selection = hit.transform;
                    if (!Kezelo.enabled)
                    {
                        Kezelo.enabled = true;
                    }
                    if (Input.GetMouseButtonDown(0))
                    {
                        mouseButtonHold = true;
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        mouseButtonHold = false;
                        kezeloScript.KezeloKepPiros();
                    }
                    Kezelo.transform.position = cameraMain.WorldToScreenPoint(selection.position);
                }
                else
                {
                    if (Kezelo.enabled)
                    {
                        Kezelo.enabled = false;
                    }
                    kezeloScript.KezeloKepFeher();
                    if (mouseButtonHold)
                    {
                       NyilScript.Mutatas(Nyil,cameraMain.WorldToScreenPoint(selection.position), new Vector3(Screen.width/2,Screen.height/2,0) );
                       Nyil.enabled = true;
                    }
                    else
                    {
                        Nyil.enabled = false;
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