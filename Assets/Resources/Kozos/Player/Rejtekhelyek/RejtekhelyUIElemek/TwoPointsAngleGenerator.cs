using System;
using UnityEngine;

namespace Resources.Kozos.Player.Rejtekhelyek.RejtekhelyUIElemek
{
    public abstract class TwoPointsAngleGenerator
    {
        public static float CalculeAngle(Vector3 start, Vector3 arrival)
        {
            var deltaX = Math.Pow((arrival.x - start.x), 2);
            var deltaY = Math.Pow((arrival.y - start.y), 2);

            var radian = Math.Atan2((arrival.y - start.y), (arrival.x - start.x));
            var angle = (radian * (180 / Math.PI) + 360) % 360;
             return (float) angle;
          
            /*
            float xDiff = arrival.x - start.x;
            float yDiff = arrival.y - start.y;
            Debug.Log("Vege");
            Debug.Log(start.x);
            Debug.Log(start.y);
            Debug.Log(arrival.x);
            Debug.Log(arrival.y);
            return (float) (Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI);*/
           
        }

        public static float CalculeDistance(Vector3 start, Vector3 arrival)
        {
            var deltaX = Math.Pow((arrival.x - start.x), 2);
            var deltaY = Math.Pow((arrival.y - start.y), 2);

            var distance = Math.Sqrt(deltaY + deltaX);

            return (float) distance;
        }
    }
}