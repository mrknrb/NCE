using UnityEngine;
using UnityEngine.UI;

namespace Resources.Menu.Elemek.MenuElemek.CustomGameMenu
{
    public class CsuszdaElemMrk : MonoBehaviour
    {
        public Slider csuszka;
        public GameObject fill;
        public GameObject handle;
        public GameObject backGround;

        public void Locker(bool locked)
        {
            if (locked)
            {
                csuszka.interactable = false;
                fill.GetComponent<Image>().color = new Color(0.91f, 0.89f, 0.46f);

                handle.GetComponent<Image>().color = new Color(0.14f, 0.14f, 0.14f);
                backGround.GetComponent<Image>().color = new Color(0.84f, 0.82f, 0.42f);
            }
            else
            {
                csuszka.interactable = true;
                fill.GetComponent<Image>().color = new Color(0.18f, 0.77f, 0.64f);

                handle.GetComponent<Image>().color = new Color(0.14f, 0.14f, 0.14f);
                backGround.GetComponent<Image>().color = new Color(0.16f, 0.66f, 0.55f);
            }
        }
    }
}