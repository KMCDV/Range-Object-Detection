using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public string ObjectName;
    public TextMeshProUGUI objectNameWorldText;

    private void Start()
    {
        objectNameWorldText.gameObject.SetActive(false);
        objectNameWorldText.text = ObjectName;
    }

    public void OnInteractStart()
    {
        objectNameWorldText.gameObject.SetActive(true);
    }

    public void OnInteractEnd()
    {
        objectNameWorldText.gameObject.SetActive(false);
    }

    private void OnMouseEnter()
    {
        OnInteractStart();
    }

    private void OnMouseExit()
    {
        OnInteractEnd();
    }
}
