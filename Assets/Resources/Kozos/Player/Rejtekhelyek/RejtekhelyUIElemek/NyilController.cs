using UnityEngine;
using UnityEngine.UI;

namespace Resources.Kozos.Player.Rejtekhelyek.RejtekhelyUIElemek
{
    public class NyilController
    {
        public Image nyil;
        private PlayerHivok playerHivok;
        private UpdateCaller updateCaller;
        private GameObject RejtekHelyStart;
        private GameObject RejtekHelyFinish;
        private RectTransform nyilTransform;
        
        public NyilController(PlayerHivok playerHivok2)
        {
            updateCaller = GameObject.Find("UpdateCallerGameObject").GetComponent<UpdateCaller>();
            playerHivok = playerHivok2;
            nyil = playerHivok2.Nyil;
            nyil.enabled = false;
            nyilTransform = nyil.GetComponent<RectTransform>();
        }

        private bool nyilBESeged;
        public void GrabbingStart(GameObject RejtekHelyStart2)
        {
            
            RejtekHelyStart = RejtekHelyStart2;

            updateCaller.update += GrabbingLoop;
          
            nyilBESeged=true;
        }  
        public void GrabbingEnd()
                 {
                     updateCaller.update -= GrabbingLoop;
                     nyilBESeged=false;
                 }
        public void GrabbingKetPontKozottStart(GameObject RejtekHelyStart2,GameObject RejtekHelyFinish2)
        {
            
            RejtekHelyStart = RejtekHelyStart2;
            RejtekHelyFinish = RejtekHelyFinish2;
            updateCaller.update += GrabbingLoopKettoPontKozott;
          
            nyilBESeged=true;
        }
        public void GrabbingKetPontKozottEnd()
        {
            
          
            updateCaller.update -= GrabbingLoopKettoPontKozott;
          
            nyilBESeged=false;
        }
      
        void GrabbingLoop()
        {
          
            var startVector = playerHivok.CameraPlayer.WorldToScreenPoint(RejtekHelyStart.transform.position);
            var finishVector = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            var Angle = TwoPointsAngleGenerator.CalculeAngle(startVector, finishVector);
            var Rotation = Quaternion.Euler(0, 0, Angle);
            // Debug.Log(Angle);
            nyil.transform.position = startVector;
            nyilTransform.rotation = Rotation;

            var Distance = TwoPointsAngleGenerator.CalculeDistance(startVector, finishVector);
            nyilTransform.sizeDelta = new Vector2(Distance, 20);
            if (nyilBESeged)
            {
                nyil.enabled = true;
            }
            else
            {
                nyil.enabled = false;
            }
            
        }
        void GrabbingLoopKettoPontKozott()
        {
          
            var startVector = playerHivok.CameraPlayer.WorldToScreenPoint(RejtekHelyStart.transform.position);
            var finishVector = playerHivok.CameraPlayer.WorldToScreenPoint(RejtekHelyFinish.transform.position);
            var Angle = TwoPointsAngleGenerator.CalculeAngle(startVector, finishVector);
            var Rotation = Quaternion.Euler(0, 0, Angle);
            // Debug.Log(Angle);
            nyil.transform.position = startVector;
            nyilTransform.rotation = Rotation;

            var Distance = TwoPointsAngleGenerator.CalculeDistance(startVector, finishVector);
            nyilTransform.sizeDelta = new Vector2(Distance, 20);
            if (nyilBESeged)
            {
                nyil.enabled = true;
            }
            else
            {
                nyil.enabled = false;
            }
            
        }
    }
}