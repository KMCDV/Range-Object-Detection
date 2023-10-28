using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectFinder : MonoBehaviour
{
    //public static event Action FinderActived;
    public delegate void MySuperInteractableAction(Transform sender);
    public static event MySuperInteractableAction MyEvent;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            MyEvent?.Invoke(transform);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 10f);
    }
}
