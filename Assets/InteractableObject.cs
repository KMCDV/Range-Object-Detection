using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public abstract class InteractableObject : MonoBehaviour, IInteratableObject
    {
        [SerializeField] internal TextMeshProUGUI _textMeshProUGUI;

        public virtual void Awake()
        {
            _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>(true);
        }

        public virtual void Start()
        {
            _textMeshProUGUI.text = transform.parent.gameObject.name;
            _textMeshProUGUI.gameObject.SetActive(false);
        }
        
        public virtual Vector3 GetObjectPosition()
        {
            return transform.position;
        }

        public virtual void HighlightObject()
        {
            _textMeshProUGUI.gameObject.SetActive(true);
            Debug.Log($"I am highlighted {transform.parent.gameObject.name}");
        }
    
        public virtual void DisableHighlight()
        {
            _textMeshProUGUI.gameObject.SetActive(false);
            Debug.Log($"I am disabled {transform.parent.gameObject.name}");
        }
        
    }
}