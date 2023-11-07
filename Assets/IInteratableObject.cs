using UnityEngine;

namespace DefaultNamespace
{
    public interface IInteratableObject
    {
        public Vector3 GetObjectPosition();
        public void HighlightObject();
        public void DisableHighlight();
    }
}