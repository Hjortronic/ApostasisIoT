using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Apostasis.Runtime;
using UnityOSC;
public class MyTestClass : ApostasisBehaviour{

    Light light;

    void Start() {
        light = gameObject.GetComponent<Light>();
        if (light == null) {
            Debug.Log("light is null");
        }
    }

    public ApostasisGlobalVariableReader globalReader;
    public override void OnServerOscRecieved (OscMessage oscMessage) {
        float v = oscMessage.GetFloat(0);
        float i = (8.0f/1024.0f)*v;
        light.intensity = i;
        Debug.Log(i);

    }

    protected override void OnServerUpdate() {
        // Debug.Log(globalReader.IntValue);
    }
}
