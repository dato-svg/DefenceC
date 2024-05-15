using UnityEngine;

namespace Component
{
    public class DestroyComponent : MonoBehaviour
    {
        public void DestroyThisObject()
        {
            Destroy(gameObject);
        }
    }
}
