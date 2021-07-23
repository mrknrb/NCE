using UnityEngine;

namespace Resources.Game.Elemek.GridElements
{
    public class Elem
    {
        public Elem()
        {
            tanuloElem = new TanuloElem();
        }

        public int elemid;
        public int padid;


        public string tipus;


        public TanuloElem tanuloElem;


        public GameObject gameObject;
    }
}