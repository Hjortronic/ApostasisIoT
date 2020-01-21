using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour {
    protected float value;

    public float GetValue() {
        return value;
    }
}