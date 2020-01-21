using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : Reaction {

    public static float tween(float targetMin, float targetMax, float sourceMin, float sourceMax, float value)
    {
        float steps = sourceMax - sourceMin;
        float size  = (targetMax - targetMin) / steps;
        return (size * value) + targetMin;
    }
    
}