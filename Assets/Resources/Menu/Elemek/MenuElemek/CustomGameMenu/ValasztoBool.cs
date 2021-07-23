using UnityEngine;
using UnityEngine.UI;

namespace Resources.Menu.Elemek.MenuElemek.CustomGameMenu
{
    public class ValasztoBool : MonoBehaviour
    {
        public Toggle toggle;
        public void Locker(bool locked)
        {
            if (locked)
            {
                toggle.interactable = false;
                toggle.image.color=new Color(0.91f, 0.89f, 0.46f);
                
            }
            else
            {
                toggle.interactable = true;
                toggle.image.color=new Color(0.18f, 0.77f, 0.64f);
            }
        }
    }
}
