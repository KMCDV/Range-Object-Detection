using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class InteractiveObjectFinder : MonoBehaviour
{
    public LayerMask interactableLayerMask;
    [Range(0f, 50f)]
    public float range;

    public KeyCode keyToActivate = KeyCode.Q;
    public bool shouldWorkOnHold = true;
    private Collider[] _interactables;
    [SerializeField, Range(0f, 2f)] private float showDelay = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(keyToActivate))
        {
            _interactables = Physics.OverlapSphere(transform.position, range, interactableLayerMask, QueryTriggerInteraction.Collide);

            StartCoroutine(InteractWithObjectsDelay());
        }

        if (Input.GetKeyUp(keyToActivate))
        {
            if(shouldWorkOnHold == false)
                return;
            
            StopAllCoroutines();
            foreach (var interactable in _interactables)
            {
                interactable.GetComponent<InteractiveObject>()?.OnInteractEnd();
            }
        }
    }

    public IEnumerator InteractWithObjectsDelay()
    {
        _interactables = _interactables.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToArray();
        foreach (Collider interactable in _interactables)
        {
            interactable.GetComponent<InteractiveObject>()?.OnInteractStart();
            yield return new WaitForSeconds(showDelay);
        }
        
        if (shouldWorkOnHold == false)
        {
            foreach (var interactable in _interactables)
            {
                interactable.GetComponent<InteractiveObject>()?.OnInteractEnd();
            }
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);

        if (Application.isPlaying)
        {
            Collider[] interactables = Physics.OverlapSphere(transform.position, range, interactableLayerMask, QueryTriggerInteraction.Collide);
            foreach (var interactable in interactables)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawCube(interactable.transform.position, interactable.transform.lossyScale);
            }
        }
    }
#endif
}
