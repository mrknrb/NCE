namespace Resources.Game.Elemek.Tanar.Actions.ActionParts.Latas
{
    public class Latas
    {
        private Latoszog latoszog;
        private GameMain gameMain;
        public Latas(GameMain gameMain2)
        {
            gameMain = gameMain2;
            latoszog=new Latoszog(gameMain);
        }
    }
}