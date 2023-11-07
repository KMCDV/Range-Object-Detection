using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlighter : MonoBehaviour
{

    public static event Action<Vector3, float> OnHighlightEnable;
    public static event Action OnHighlightDisable;
    [SerializeField, Range(0f, 10f)] private float objectDistance = 2f;
    
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            OnHighlightEnable?.Invoke(transform.position, objectDistance);
            Debug.Log("Down");
        }
        
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            OnHighlightDisable?.Invoke();
            Debug.Log("Up");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0.56f, 0.64f, 0.31f);
        Gizmos.DrawSphere(transform.position, objectDistance);
    }
}
