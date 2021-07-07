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
        private Dictionary<string, IPuskaKozos> puskaList;


        public RejtekhelyManager(PlayerMain playerMain )
        {
            playerHivok = playerMain.playerHivok;
            lookWithMouse = playerMain.lookWithMouse;
            nyilController = new NyilController(playerMain.playerHivok);
            rejtekhelyek = new Dictionary<string, RejtekHely>();
            rejtekhelyekInput = new RejtekhelyekInput(playerHivok, lookWithMouse, this);


            for (int i = 0; i < playerHivok.RejtekhelyHivok.Count; i++)
            {
                rejtekhelyek.Add(playerHivok.RejtekhelyHivok[i].transform.name, new RejtekHely(i, playerHivok, rejtekhelyekInput, lookWithMouse));
            }


            lookWithMouse.ZoomMode += ZoomModeBekapcs;
            puskaList = new Dictionary<string, IPuskaKozos>();
        }

        public bool zoomModeBekapcsBlock;

        public void ZoomModeBekapcs(bool BE)
        {
            if (!zoomModeBekapcsBlock)
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
        }

        public void PuskakBetoltese(Dictionary<string, IPuskaKozos> puskak)
        {
            puskaList = puskak;
            foreach (var puska in puskaList)
            {
                rejtekhelyek[puska.Value.puskaData.rejtekhelyid].PuskaBetoltes(puska.Value);
                rejtekhelyek[puska.Value.puskaData.rejtekhelyid].PuskaBetoltes(puska.Value);
            }

            UresRejtekHelyekAktival(false);
        }


        public void RejtekHelyMegnyit(string rejtekhelyname)
        {
            lookWithMouse.ZoomMax();
        }

        public void FoglaltRejtekHelyetAktival(bool aktival)
        {
            //MindenRejtekHelyetAktival(false);
            foreach (var rejtekHelyDict in rejtekhelyek)
            {
                if (rejtekHelyDict.Value.puska != null)
                {
                    rejtekHelyDict.Value.RejtekhelyAktival(aktival);
                    rejtekHelyDict.Value.RejtekHelyHighLight(aktival);
                }
            }
        }

        public void MindenRejtekHelyetAktival(bool aktival)
        {
            foreach (var rejtekHelyDict in rejtekhelyek)
            {
                rejtekHelyDict.Value.RejtekhelyAktival(aktival);
                rejtekHelyDict.Value.RejtekHelyHighLight(aktival);
            }
        }

        public void UresRejtekHelyekAktival(bool aktival)
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
        public void rejtekhelyGrabbing(string rejtekhelyname)
        {
            var rejtekhely = rejtekhelyek[rejtekhelyname];
            nyilController.GrabbingStart(rejtekhely.rejtekHelyGameObject);
            UresRejtekHelyekAktival(true);
            FoglaltRejtekHelyetAktival(false);
        }

        public void GrabbingMenuRejtekHelyekAktival(string FromRejtekHely, string ToRejtekhely)
        {
            MindenRejtekHelyetAktival(false);
            rejtekhelyek[FromRejtekHely].RejtekhelyAktival(true);
            rejtekhelyek[ToRejtekhely].RejtekhelyAktival(true);
            rejtekhelyek[FromRejtekHely].RejtekHelyHighLight(true);
            rejtekhelyek[ToRejtekhely].RejtekHelyHighLight(true);
        }

       
        public void rejtekhelyGrabbingCancel()
        {
            nyilController.GrabbingEnd();
            UresRejtekHelyekAktival(false);
            FoglaltRejtekHelyetAktival(true);
        }

        public void rejtekhelyPuskaGrabToAnother(string innen, string ide)
        {
            if (rejtekhelyek[innen].puska != null && rejtekhelyek[ide].puska == null)
            {
                rejtekhelyek[ide].PuskaBerakas(rejtekhelyek[innen].PuskaKivetel());
            }

            nyilController.GrabbingEnd();
            UresRejtekHelyekAktival(false);
            FoglaltRejtekHelyetAktival(true);
            playerHivok.GrabbingMenuText.SetActive(false);
        }

        public void rejtekhelyGrabToAnotherJelzesStart(string start, string finish)
        {
            nyilController.GrabbingKetPontKozottStart(rejtekhelyek[start].rejtekHelyGameObject, rejtekhelyek[finish].rejtekHelyGameObject);
        }

        public void rejtekhelyGrabToAnotherJelzesEnd()
        {
            nyilController.GrabbingKetPontKozottEnd();
        }

        public void rejtekhelyGrabToAnotherMenu(bool BE)
        {
            playerHivok.GrabbingMenuText.SetActive(BE);
        }
    }
}