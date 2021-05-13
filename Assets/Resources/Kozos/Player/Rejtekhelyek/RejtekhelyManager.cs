using System;
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
            rejtekhelyekInput = new RejtekhelyekInput(playerHivok,lookWithMouse);


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

            lookWithMouse.ZoomMode += ZoomModeBekapcs;
            puskaList = new Dictionary<string, PuskaKozos>();
        }

        void ZoomModeBekapcs(bool BE)
        {
            if (BE)
            {
                MindenRejtekHelyetAktival(false);
            }
            else
            {
                FoglaltRejtekHelyetAktival(true);
            }
        }

        public void PuskakBetoltese(Dictionary<string, PuskaKozos> puskak)
        {
            puskaList = puskak;
            foreach (var puska in puskaList)
            {
                rejtekhelyek[puska.Value.puskaData.rejtekhelyid].PuskaBetoltes(puska.Value);
                rejtekhelyek[puska.Value.puskaData.rejtekhelyid].PuskaBetoltes(puska.Value);
            }

            UresRejtekHelyekAktival(false);
        }


        void RejtekHelyMegnyit(string rejtekhelyname)
        {
            lookWithMouse.ZoomMax();
        }

        void FoglaltRejtekHelyetAktival(bool aktival)
        {
            foreach (var rejtekHelyDict in rejtekhelyek)
            {
                if (rejtekHelyDict.Value.puska != null)
                {
                    rejtekHelyDict.Value.RejtekhelyAktival(aktival);
                    rejtekHelyDict.Value.RejtekHelyHighLight(aktival);
                }
            }
        }

        void MindenRejtekHelyetAktival(bool aktival)
        {
            foreach (var rejtekHelyDict in rejtekhelyek)
            {
                rejtekHelyDict.Value.RejtekhelyAktival(aktival);
                rejtekHelyDict.Value.RejtekHelyHighLight(aktival);
            }
        }

        void UresRejtekHelyekAktival(bool aktival)
        {
            foreach (var rejtekHelyDict in rejtekhelyek)
            {
                if (rejtekHelyDict.Value.puska == null)
                {
                    rejtekHelyDict.Value.RejtekhelyAktival(aktival);
                    rejtekHelyDict.Value.RejtekHelyHighLight(aktival);
                }
            }
        }

        void rejtekhelyGrabbing(string rejtekhelyname)
        {
            var rejtekhely = rejtekhelyek[rejtekhelyname];
            nyilController.GrabbingStart(rejtekhely.rejtekHelyGameObject);
            UresRejtekHelyekAktival(true);
            FoglaltRejtekHelyetAktival(false);
        }

        void rejtekhelyGrabbingCancel()
        {
            nyilController.GrabbingEnd();
            UresRejtekHelyekAktival(false);
            FoglaltRejtekHelyetAktival(true);
        }

        void rejtekhelyPuskaGrabToAnother(string innen, string ide)
        {
            if (rejtekhelyek[innen].puska != null && rejtekhelyek[ide].puska == null)
            {
                rejtekhelyek[ide].PuskaBerakas(rejtekhelyek[innen].PuskaKivetel());
            }

            nyilController.GrabbingEnd();
            UresRejtekHelyekAktival(false);
            FoglaltRejtekHelyetAktival(true);
        }
    }
}