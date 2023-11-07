using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TRIGGER_ObjectHighlighter : MonoBehaviour
{
    [SerializeField] private List<Banana> _highlightReceivers;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Banana receiver))
        {
            if(_highlightReceivers.Contains(receiver))
                return;
            _highlightReceivers.Add(receiver);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Banana receiver))
        {
            if(_highlightReceivers.Contains(receiver))
                _highlightReceivers.Remove(receiver);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            foreach (Banana receiver in _highlightReceivers)
            {
                receiver.HighlightObject();
            }
        }
        
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            foreach (Banana receiver in _highlightReceivers)
            {
                receiver.DisableHighlight();
            }
        }
    }
}
