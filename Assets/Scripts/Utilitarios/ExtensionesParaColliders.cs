using UnityEngine;

namespace Utils
{
    public static class ColliderExtensions
    {
        public static bool ContieneLaEtiqueta(this Collider collider, string etiqueta)
        {
            return collider.CompareTag(etiqueta);
        }
    }
}