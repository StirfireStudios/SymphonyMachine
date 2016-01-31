using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Jam.Utils.Layout
{
    /// The layout for a GameObject
    public struct LayoutManager
    {
        /// Apply a layout to a set of game objects
        public static void ApplyLayout(ILayout layout, IEnumerable<GameObject> objects)
        {
            foreach (var lp in layout.Layout(objects))
            {
                ApplyLayout(lp);
            }
        }

        /// Apply a layout object
        public static void ApplyLayout(LayoutObject layoutRequest)
        {
            layoutRequest.gameObject.transform.position = layoutRequest.position;
            layoutRequest.gameObject.transform.rotation = layoutRequest.rotation;
            layoutRequest.gameObject.transform.localScale = layoutRequest.scale;
        }
    }
}
