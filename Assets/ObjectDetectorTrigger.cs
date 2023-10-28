using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetectorTrigger : MonoBehaviour
{
    public List<Collider> FoundColliders = new List<Collider>();

    private void OnEnable()
    {
        FoundColliders.Clear();
    }
}
