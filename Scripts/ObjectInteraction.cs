using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : Interaction {
    public Transform trf;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(trf.position, trf.TransformDirection(Vector3.forward), 100.0f))
            {
                value = (value > 0.5f) ? 0.0f : 1.0f;
            }
        }
    }
}