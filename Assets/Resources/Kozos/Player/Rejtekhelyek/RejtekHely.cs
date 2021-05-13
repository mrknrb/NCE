using System;
using Resources.Kozos.Player.Puskazas.PuskazasiModszerek;
using UnityEngine;
using UnityEngine.UI;

namespace Resources.Kozos.Player.Rejtekhelyek
{
    public class RejtekHely
    {
        public GameObject rejtekHelyGameObject;
        public GameObject rejtekHelyJelGameObject;
        private RejtekHelyJelHivok rejtekHelyJelHivok;
        public GameObject rejtekHelyFelfedveGameObject;
        public Image rejtekHelyJelLogo;
        public Image rejtekHelyJelHatter;
        public string rejtekHelyName;
        private PlayerHivok playerHivok;
        private UpdateCaller updateCaller;
        private LookWithMouse lookWithMouse;
        public PuskaKozos puska;

        public RejtekHely(int i, PlayerHivok playerHivok2, RejtekhelyekInput rejtekhelyekInput, LookWithMouse lookWithMouse2)
        {
            updateCaller = GameObject.Find("UpdateCallerGameObject").GetComponent<UpdateCaller>();
            playerHivok = playerHivok2;

            rejtekHelyGameObject = playerHivok2.RejtekhelyHivok[i];

            rejtekHelyJelGameObject = GameObject.Instantiate(UnityEngine.Resources.Load("Kozos/Player/RejtekHelyek/RejtekhelyUIElemek/RejtekHelyJel") as GameObject);
            rejtekHelyJelGameObject.transform.SetParent(playerHivok.UIKezelo.transform);
            rejtekHelyJelHivok = rejtekHelyJelGameObject.GetComponent<RejtekHelyJelHivok>();
            rejtekHelyJelLogo = rejtekHelyJelHivok.Logo.GetComponent<Image>();
            rejtekHelyJelHatter = rejtekHelyJelHivok.Hatter.GetComponent<Image>();
            rejtekHelyFelfedveGameObject = playerHivok2.RejtekhelyFelfedveHivok[i];
            rejtekHelyName = rejtekHelyGameObject.transform.name;
            updateCaller.update += RejtekHelyJelMozgas;
            lookWithMouse = lookWithMouse2;
            lookWithMouse.ZoomModeOn += RejtekhelyZoomModeOn;
            lookWithMouse.ZoomModeOff += RejtekhelyZoomModeOff;
        }

        public void PuskaBetoltes(PuskaKozos puska2)
        {
            puska = puska2;
            puska.PuskaGameObject.transform.position = rejtekHelyFelfedveGameObject.transform.position;
            puska.PuskaGameObject.transform.rotation = rejtekHelyFelfedveGameObject.transform.rotation;

            rejtekHelyJelLogo.sprite = puska.puskaLogo;
            rejtekHelyJelHatter.sprite = rejtekHelyJelGameObject.GetComponent<RejtekHelyJelSpritesHivok>().KekHatter;
        }

        public PuskaKozos PuskaKivetel()
        {
            rejtekHelyJelHatter.sprite = rejtekHelyJelGameObject.GetComponent<RejtekHelyJelSpritesHivok>().Atlatszo;
            rejtekHelyJelLogo.sprite = rejtekHelyJelGameObject.GetComponent<RejtekHelyJelSpritesHivok>().Atlatszo;
            var d = puska;
            puska = null;
            return d;
        }

        public void PuskaBerakas(PuskaKozos puska2)
        {
            puska = puska2;
            puska.PuskaGameObject.transform.position = rejtekHelyFelfedveGameObject.transform.position;
            puska.PuskaGameObject.transform.rotation = rejtekHelyFelfedveGameObject.transform.rotation;
            rejtekHelyJelLogo.sprite = puska.puskaLogo;
            rejtekHelyJelHatter.sprite = rejtekHelyJelGameObject.GetComponent<RejtekHelyJelSpritesHivok>().KekHatter;
        }

        void RejtekhelyZoomModeOn()
        {
            rejtekHelyGameObject.SetActive(false);
            rejtekHelyJelGameObject.SetActive(false);
        }

        void RejtekhelyZoomModeOff()
        {
            rejtekHelyGameObject.SetActive(true);
            rejtekHelyJelGameObject.SetActive(true);
        }

        void RejtekHelyJelMozgas()
        {
            //Debug.Log(playerHivok.CameraPlayer.WorldToScreenPoint(rejtekHelyGameObject.transform.position).x);
            //  Debug.Log( rejtekHelyJelGameObject.transform.position.x);

            rejtekHelyJelGameObject.transform.position = playerHivok.CameraPlayer.WorldToScreenPoint(rejtekHelyGameObject.transform.position);
        }

        public void RejtekHelyHighLight(bool kiemel)
        {
            if (kiemel)
            {
                rejtekHelyJelHatter.sprite = rejtekHelyJelGameObject.GetComponent<RejtekHelyJelSpritesHivok>().KekHatter;
            }
            else
            {
                rejtekHelyJelHatter.sprite = rejtekHelyJelGameObject.GetComponent<RejtekHelyJelSpritesHivok>().Atlatszo;
            }
        }
    }
}