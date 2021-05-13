namespace Resources.Game.DataClassok.PuskaMentesek
{
    public struct CheatSheetPrintedMentes:PuskaKozosMentes
    {
        public string puskaid { get; set; }
        public PuskaTipusok tipus { get; set; }
        public bool locked { get; set; }
        public bool hasznalva { get; set; }
        public int begin { get; set; }
        public int end { get; set; }
        public string rejtekhelyid { get; set; }
        public string rejtekhely2 { get; set; }
    }
}