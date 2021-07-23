using System.Collections.Generic;
using Resources.Game.DataClassok;
using Resources.Kozos.Player.Puskazas.PuskazasiModszerek;
using Resources.Kozos.Player.Puskazas.PuskazasiModszerek.CheatSheetPrinted;
using Resources.Kozos.Player.Puskazas.PuskazasiModszerek.TelefonPuska;
using UnityEngine;

namespace Resources.Kozos.Player.Puskazas
{
    public class PuskazasManager
    {
        private Mentes mentes;
        public Dictionary<string,IPuskaKozos> puskaList;
        PlayerHivok playerHivok;
        private LookWithMouse lookWithMouse;
        private GameObject playerGameObject;
        private PlayerMain playerMain;
        public PuskazasManager(PlayerMain playerMain2)
        {
            playerMain = playerMain2;
            playerGameObject = playerMain.playerGameObject;
            playerHivok = playerMain.playerHivok;
            puskaList=new Dictionary<string,IPuskaKozos>();
            lookWithMouse = playerMain.lookWithMouse;
        }

        public void  PuskakBetoltese(Mentes mentes2)
        {
            mentes = mentes2;
            foreach (var puskamentes in  mentes2.puskaMentes)
            {
                if (puskamentes.tipus==PuskaTipusok.cheatSheetPrinted)
                {
                    puskaList.Add(puskamentes.puskaid,new CheatSheetPrintedMain(puskamentes, playerMain));
                }
                else if (puskamentes.tipus==PuskaTipusok.telefon)
                {
                    puskaList.Add(puskamentes.puskaid,new TelefonPuskaMain(puskamentes,playerMain));
                }
            }
        }

        void PuskakAktivalasa(bool BE)
        {
            foreach (var puska in puskaList)
            {
                puska.Value.Aktivalas(BE);
            }
        }
       
    }
}