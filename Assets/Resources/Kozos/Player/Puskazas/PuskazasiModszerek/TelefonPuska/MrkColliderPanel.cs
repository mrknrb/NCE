using UnityEngine;

namespace Resources.Kozos.Player.Puskazas.PuskazasiModszerek.TelefonPuska
{
    public class MrkColliderPanel : MonoBehaviour
    {
  
        void Start()
        {
            var collider= gameObject.AddComponent<BoxCollider>();
            var rectransform= gameObject.GetComponent<RectTransform>();
            collider.size = new Vector3(rectransform.sizeDelta.x, rectransform.sizeDelta.y, 0.01f);
        }

   
        void Update()
        {
        
        }
    }
}
