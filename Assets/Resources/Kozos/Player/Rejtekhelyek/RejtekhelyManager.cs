using System.Collections.Generic;
using Resources.Kozos.Player.Puskazas.PuskazasiModszerek;
using Resources.Kozos.Player.Rejtekhelyek.RejtekhelyUIElemek;
using UnityEngine;

namespace Resources.Kozos.Player.Rejtekhelyek
{
    public class RejtekhelyManager
    {
        private Dictionary<string, RejtekHely> rejtekhelyek;
        private RejtekhelyekInput rejtekhelyekInput;
        private PlayerHivok playerHivok;
        private LookWithMouse lookWithMouse;
        private NyilController nyilController;
        private Dictionary<string, PuskaKozos> puskaList;

        public RejtekhelyManager(PlayerHivok playerHivok2, LookWithMouse lookWithMouse2)
        {
            nyilController = new NyilController(playerHivok2);
            lookWithMouse = lookWithMouse2;
            rejtekhelyek = new Dictionary<string, RejtekHely>();
            playerHivok = playerHivok2;
            rejtekhelyekInput = new RejtekhelyekInput(playerHivok);


            for (int i = 0; i < playerHivok.RejtekhelyHivok.Count; i++)
            {
                rejtekhelyek.Add(playerHivok.RejtekhelyHivok[i].transform.name, new RejtekHely(i, playerHivok, rejtekhelyekInput, lookWithMouse));
            }

           // rejtekhelyekInput.rejtekhelyMouseOverEvent += RejtekHelyHighLight;
           // rejtekhelyekInput.rejtekhelyMouseLeaveEvent += RejtekHelyHighLightOff;
            rejtekhelyekInput.rejtekhelyKlikkEvent += RejtekHelyMegnyit;
            rejtekhelyekInput.rejtekhelyGrabStartEvent += rejtekhelyGrabbing;
            rejtekhelyekInput.rejtekhelyGrabCancelEvent += rejtekhelyGrabbingCancel;
            rejtekhelyekInput.rejtekhelyGrabToAnotherEvent += rejtekhelyPuskaGrabToAnother;
            puskaList = new Dictionary<string, PuskaKozos>();
        }

        public void PuskakBetoltese(Dictionary<string, PuskaKozos> puskak)
        {
            puskaList = puskak;
            foreach (var puska in puskaList)
            {
                rejtekhelyek[puska.Value.puskaData.rejtekhelyid].PuskaBetoltes(puska.Value);
            }
        }


        void RejtekHelyMegnyit(string rejtekhelyname)
        {
            lookWithMouse.ZoomMax();
        }

        void UresRejtekHelyekKiemel(bool kiemel)
        {
            foreach (var rejtekHelyDict in rejtekhelyek)
            {
                if (rejtekHelyDict.Value.puska == null)
                {
                          rejtekHelyDict.Value.RejtekHelyHighLight(kiemel);
                 
                }
            }
        }

        void rejtekhelyGrabbing(string rejtekhelyname)
        {
           // Debug.Log("ggggg");
            var rejtekhely = rejtekhelyek[rejtekhelyname];
            nyilController.GrabbingStart(rejtekhely.rejtekHelyGameObject);
            UresRejtekHelyekKiemel(true);
        }

        void rejtekhelyGrabbingCancel()
        {
            nyilController.GrabbingEnd();
            UresRejtekHelyekKiemel(false);
        }

        void rejtekhelyPuskaGrabToAnother(string innen, string ide)
        {
            rejtekhelyek[ide].PuskaBerakas(rejtekhelyek[innen].PuskaKivetel());
            nyilController.GrabbingEnd();
            UresRejtekHelyekKiemel(false);
        }
    }
}