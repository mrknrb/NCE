using UnityEngine;
using UnityEngine.EventSystems;

namespace Resources.Menu.Elemek.MenuElemek.CustomGameMenu
{
    public class CheatingTab : MonoBehaviour, IPointerClickHandler
    {
        public GameObject cheatingWindow;
        public GameObject cheatingWindowsPanel;

        public void OnPointerClick(PointerEventData eventData)
        {
        

            foreach (Transform child in cheatingWindowsPanel.transform)
            {
                GameObject otherCheatingWindow = child.gameObject;
                otherCheatingWindow.SetActive(false);
            }


            cheatingWindow.SetActive(true);
        }
    }
}