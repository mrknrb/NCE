using UnityEngine;

namespace Resources.Menu.Elemek.Szoba.Ablak
{
    public class Villamlas : MonoBehaviour
    {
        public Material ablak;

        public Material ablakVillam;
        private MeshRenderer ablakMeshRenderer;

        // Start is called before the first frame update
        void Start()
        {
            ablakMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        }

        float elapsed = 0f;
        float kovetkezoIdo = 5f;
        // Update is called once per frame
        void Update()
        {
            elapsed += Time.deltaTime;
            if (elapsed >=  kovetkezoIdo)
            {
                elapsed = elapsed % 1f;
                Villam();
                kovetkezoIdo = Random.Range(10f, 40f);
            }
        }

        void Villam()
        {
        
            ablakMeshRenderer.material = ablakVillam;
            Invoke("VillamVege", 0.1f);

        }
        void VillamVege()
        {
            ablakMeshRenderer.material = ablak;
            Invoke("Villam2", 0.1f);
        }
        void Villam2()
        {
            ablakMeshRenderer.material = ablakVillam;
            Invoke("VillamVege2", 0.1f);
        }
        void VillamVege2()
        {
            ablakMeshRenderer.material = ablak;
        }
    }
}