using UnityEngine;
using UnityEngine.UI;

namespace Resources.Kozos.Player.Puskazas.PuskazasiModszerek
{
    public class PuskaGombJel
    {
        private Image Jel;
        private GameObject Gomb;
        private Camera cameraplayer;
        private UpdateCaller updateCaller;

        public PuskaGombJel(Image Jel2, GameObject Gomb2, Camera cameraplayer2)
        {
            Jel = Jel2;
            Gomb = Gomb2;
            cameraplayer = cameraplayer2;
            updateCaller = GameObject.Find("UpdateCallerGameObject").GetComponent<UpdateCaller>();
        }
        public void PuskaGombAktivalas(bool BE)
        {
            if (BE)
            {
                Gomb.SetActive(true);
                Jel.enabled = true;
                updateCaller.update += JelekMutatasaLoop;
            }
            else
            {
                Gomb.SetActive(false);
                Jel.enabled = false;
                updateCaller.update -= JelekMutatasaLoop;
            }
        }

        void JelekMutatasaLoop()
        {
            Jel.transform.position = cameraplayer.WorldToScreenPoint(Gomb.transform.position);
        }
    }
}