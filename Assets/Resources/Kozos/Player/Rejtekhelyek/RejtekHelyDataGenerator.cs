namespace Resources.Kozos.Player.Rejtekhelyek
{
    public abstract class RejtekHelyDataGenerator
    {
        static RejtekHelyData Generalas(string RejtekHelyid)
        {
            var rejtekHelyData = new RejtekHelyData();
            if (RejtekHelyid == "RejtekHely0")
            {
                rejtekHelyData.nagyPuskakhoz = false;

            } else if (RejtekHelyid == "RejtekHely1")
            {
                rejtekHelyData.nagyPuskakhoz = false;
            }
            else if (RejtekHelyid == "RejtekHely2")
            {
                rejtekHelyData.nagyPuskakhoz = true;
            }
            
            
            
            return rejtekHelyData;
        }
    }
}