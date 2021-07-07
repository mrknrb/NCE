using Resources.Game.DataClassok;
using UnityEngine;

namespace Resources.Kozos.Player.Puskazas.PuskazasiModszerek
{
    public interface IPuskaKozos
    {
        GameObject PuskaGameObject { get; set; }
        PuskaKozosMentes puskaData { get; set; }
        Sprite puskaLogo { get; set; }
        LookWithMouse lookWithMouse { get; set; }
        public void Aktivalas(bool BE);
       
    }
}