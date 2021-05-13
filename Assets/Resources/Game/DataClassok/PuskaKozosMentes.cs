namespace Resources.Game.DataClassok
{
    public interface PuskaKozosMentes
    {
        string puskaid { get; set; }
        
        PuskaTipusok tipus { get; set; }
        bool locked { get; set; }
        bool hasznalva { get; set; }
        int begin { get; set; }
        int end { get; set; }
        string rejtekhelyid { get; set; }
    }
}