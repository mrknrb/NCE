using System.Collections.Generic;
using Resources.Kozos.Player.PlayerUI.PuskaKezeloUI;
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

        public RejtekhelyManager(PlayerHivok playerHivok2, LookWithMouse lookWithMouse2)
        {
            nyilController=new NyilController(playerHivok2);
            lookWithMouse = lookWithMouse2;
            rejtekhelyek = new Dictionary<string, RejtekHely>();
            playerHivok = playerHivok2;
            rejtekhelyekInput = new RejtekhelyekInput(playerHivok);

            for (int i = 0; i < playerHivok.RejtekhelyHivok.Count; i++)
            {
                rejtekhelyek.Add(playerHivok.RejtekhelyHivok[i].transform.name, new RejtekHely(i, playerHivok, rejtekhelyekInput, lookWithMouse));
            }

            rejtekhelyekInput.rejtekhelyMouseOverEvent += RejtekHelyHighLight;
            rejtekhelyekInput.rejtekhelyMouseLeaveEvent += RejtekHelyHighLightOff;
            rejtekhelyekInput.rejtekhelyKlikkEvent += RejtekHelyMegnyit;
            rejtekhelyekInput.rejtekhelyGrabStartEvent+= rejtekhelyGrabbing;
            rejtekhelyekInput.rejtekhelyGrabCancelEvent+= rejtekhelyGrabbingCancel;
            rejtekhelyekInput.rejtekhelyGrabToAnotherEvent += rejtekhelyGrabToAnother;
        }

        void RejtekHelyHighLight(string rejtekhelyname)
        {
            rejtekhelyek[rejtekhelyname].rejtekHelyJelImage.color = Color.red;
        }

        void RejtekHelyHighLightOff()
        {
            foreach (var rejtekHelyDict in rejtekhelyek)
            {
                rejtekHelyDict.Value.rejtekHelyJelImage.color = Color.white;
            }
        }

        void RejtekHelyMegnyit(string rejtekhelyname)
        {
            lookWithMouse.ZoomMax();
        }

        void rejtekhelyGrabbing(string rejtekhelyname)
        {
            nyilController.GrabbingStart(rejtekhelyek[rejtekhelyname].rejtekHelyGameObject);
        }
        void rejtekhelyGrabbingCancel()
        {
            nyilController.GrabbingEnd();
        }
        void rejtekhelyGrabToAnother(string innen, string ide)
        {
            nyilController.GrabbingEnd();
            rejtekhelyek[ide].puskaid = rejtekhelyek[innen].puskaid;
            rejtekhelyek[innen].puskaid = "";
        }
    }
}