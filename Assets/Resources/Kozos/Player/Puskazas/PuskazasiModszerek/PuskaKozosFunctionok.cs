using UnityEngine;
using UnityEngine.UI;

namespace Resources.Kozos.Player.Puskazas.PuskazasiModszerek
{
    public abstract class PuskaKozosFunctionok
    {
        public static void JelekMutatasa(bool BE,Image Jel,GameObject Gomb,Camera cameraplayer)
        {
            
           var updateCaller = GameObject.Find("UpdateCallerGameObject").GetComponent<UpdateCaller>();
            if (BE)
            {
                updateCaller.update += JelekMutatasaLoop;
            }
            else
            {
                updateCaller.update -= JelekMutatasaLoop;
            }
            void JelekMutatasaLoop()
            {
                Jel.transform.position = cameraplayer.WorldToScreenPoint(Gomb.transform.position);
            }
            
            
            
        }

       
    }
}