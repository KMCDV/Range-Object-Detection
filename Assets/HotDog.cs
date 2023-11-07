using UnityEngine;

namespace DefaultNamespace
{
    public class HotDog : InteractableObject
    {
        [SerializeField] private ParticleSystem _particleSystem;
        
        public override void Awake()
        {
            base.Awake();
            _textMeshProUGUI.color = Color.red;
        }

        public override void HighlightObject()
        {
            base.HighlightObject();
            Debug.Log("I am hoot dooog alsadlkasjdlkasjdl");
            _particleSystem.Play();
        }
    }
}