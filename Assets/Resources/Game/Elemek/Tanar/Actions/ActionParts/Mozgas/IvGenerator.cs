using System;
using System.Collections.Generic;
using UnityEngine;
namespace Resources.Game.Elemek.Tanar.Actions.ActionParts.Mozgas
{
    public static class IvGenerator
    {
        private static List<Vector2> SarokIvVectorLista()
        {
            var lekerekitettIv = new List<Vector2>();
            //hh
            lekerekitettIv.Add(new Vector2(0.5f,0f));
            lekerekitettIv.Add(new Vector2(0.48f,0.07f));
            lekerekitettIv.Add(new Vector2(0.46f,0.18f));
            lekerekitettIv.Add(new Vector2(0.42f,0.24f));
            lekerekitettIv.Add(new Vector2(0.38f,0.32f));
            lekerekitettIv.Add(new Vector2(0.32f,0.38f));
            lekerekitettIv.Add(new Vector2(0.24f,0.42f));
            lekerekitettIv.Add(new Vector2(0.18f,0.46f));
            lekerekitettIv.Add(new Vector2(0.07f,0.48f));
            lekerekitettIv.Add(new Vector2(0f,0.5f));
            return lekerekitettIv;
        }
        
        
        
        
    }
}