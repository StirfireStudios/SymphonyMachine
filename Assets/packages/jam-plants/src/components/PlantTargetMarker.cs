using UnityEngine;
using Jam.Utils;

namespace Jam.Plants
{
    [AddComponentMenu("")]
    public class PlantTargetMarker : MonoBehaviour
    {
        public GameObject parent;
    }

    public class PlantTarget
    {
        public static PlantTargetMarker FindMarker(GameObject parent)
        {
            foreach (var cmp in Scene.FindComponents<PlantTargetMarker>())
            {
                if (cmp.parent == parent)
                {
                    return cmp;
                }
            }
            return null;
        }
    }
}
