using Resources.Kozos.Player;
using UnityEngine;

namespace Resources.Menu
{
    public class MenuMain : MonoBehaviour
    {
        private PlayerMain playerMain;
        private void Start()
        {
            playerMain=new PlayerMain();
            playerMain.playerGameObject.transform.position = new Vector3(0.817f, -0.93f, -3.738f);
        }
    }
}
