using Resources.Game.DataClassok;
using Resources.Kozos.Player.Puskazas.PuskazasiModszerek.TelefonPuska.TelefonUI;
using UnityEngine;

namespace Resources.Kozos.Player.Puskazas.PuskazasiModszerek.TelefonPuska
{
    public class TelefonPuskaMain : IPuskaKozos
    {
        public GameObject PuskaGameObject { get; set; }
        public PuskaKozosMentes puskaData { get; set; }
        public TelefonHivok telefonHivok { get; set; }
        public Sprite puskaLogo { get; set; }
        public LookWithMouse lookWithMouse { get; set; }
        private PuskaGombJel PuskaGombFel;
        private PuskaGombJel PuskaGombLe;
        private UpdateCaller updateCaller;
        private PlayerHivok playerHivok;
        private TelefonScreenScript telefonScreenScript;

        public TelefonPuskaMain(PuskaKozosMentes puskamentes,PlayerMain playerMain)
        {
            
            lookWithMouse = playerMain.lookWithMouse;
            playerHivok = playerMain.playerHivok;

            PuskaGameObject = GameObject.Instantiate(UnityEngine.Resources.Load("Kozos/Player/Puskazas/PuskazasiModszerek/TelefonPuska/Telefon") as GameObject);
            PuskaGameObject.transform.SetParent(playerMain.playerGameObject.transform);
            puskaLogo = UnityEngine.Resources.Load<Sprite>("Kozos/Player/Puskazas/Logok/TelefonLogo");
            telefonHivok = PuskaGameObject.GetComponent<TelefonHivok>();
            puskaData = puskamentes;
            updateCaller = GameObject.Find("UpdateCallerGameObject").GetComponent<UpdateCaller>();
            PuskaGombLe = new PuskaGombJel(telefonHivok.LeGombImage, telefonHivok.LeGomb, playerHivok.CameraPlayer);
            PuskaGombFel = new PuskaGombJel(telefonHivok.FelGombImage, telefonHivok.FelGomb, playerHivok.CameraPlayer);
            PuskaGombFel.PuskaGombAktivalas(true);
            PuskaGombLe.PuskaGombAktivalas(true);
            PuskaGombFel.PuskaGombAktivalas(false);
            PuskaGombLe.PuskaGombAktivalas(false);
            telefonScreenScript=new TelefonScreenScript(lookWithMouse,telefonHivok);
            
        }

        public void Aktivalas(bool BE)
        {
        }
    }
}