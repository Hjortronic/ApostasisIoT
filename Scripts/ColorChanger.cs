using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : Tween {

    public Material material;

    public Color from, to;

    public void Handle(float value) {
        var v     = Tween.tween(0, 0, 0, 1024, value);
        var color = Color.Lerp(from, to, v);
        // TODO, the material of the object, clone it.
        material.color = color;
    }
}