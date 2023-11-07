using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class OVERLAP_ObjectHighligher : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _timeDelay = .2f;
    [SerializeField] private float revelioDurationo;
    [SerializeField] private AnimationCurve _revealAnimationCurve;
    private float animationCurrentTime;

    [SerializeField] private KeyCode _leftControl = KeyCode.LeftControl;
    [SerializeField] private List<IInteratableObject> _highlightReceivers = new List<IInteratableObject>();
    [SerializeField] private LayerMask _layerMask;
    
    void Update()
    {
        if (Input.GetKeyDown(_leftControl))
        {
            animationCurrentTime = 0f;
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _layerMask, QueryTriggerInteraction.Collide);
            foreach (var hitCollider in hitColliders)
            {
                if(hitCollider.TryGetComponent(out IInteratableObject objectHighlightReceiver) == false)
                    return;
                if(_highlightReceivers.Contains(objectHighlightReceiver) == false)
                    _highlightReceivers.Add(objectHighlightReceiver);
            }
            
            GameObject sphereRenderer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphereRenderer.transform.localScale = Vector3.zero;
            sphereRenderer.transform.position = transform.position;
            sphereRenderer.GetComponent<Collider>().enabled = false;
            sphereRenderer.transform.DOScale(_radius * 2, revelioDurationo).SetEase(_revealAnimationCurve).OnUpdate(RevealObjectsInRadius);

            //_highlightReceivers = _highlightReceivers.OrderBy(x => Vector3.Distance(x.GetObjectPosition(), transform.position)).ToList();
            //StartCoroutine(ShowObjectsWithDelay(_timeDelay));
        }

        if (Input.GetKeyUp(_leftControl))
        {
            StopAllCoroutines();
            foreach (IInteratableObject objectHighlightReceiver in _highlightReceivers)
            {
                objectHighlightReceiver.DisableHighlight();
            }
            _highlightReceivers.Clear();
        }
    }

    private void RevealObjectsInRadius()
    {
        animationCurrentTime += Time.deltaTime;
        foreach (var highlightReceiver in _highlightReceivers)
        {
            if(Vector3.Distance(highlightReceiver.GetObjectPosition(), transform.position) <= _radius *  _revealAnimationCurve.Evaluate(animationCurrentTime))
                highlightReceiver.HighlightObject();
        }
    }

    private IEnumerator ShowObjectsWithDelay(float delayAmount)
    {
        foreach (var highlightReceiver in _highlightReceivers)
        {
            yield return new WaitForSeconds(delayAmount);
            highlightReceiver.HighlightObject();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
