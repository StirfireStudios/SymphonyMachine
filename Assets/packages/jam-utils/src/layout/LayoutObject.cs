using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Jam.Utils.Layout
{
    /// The layout for a GameObject
    public struct LayoutObject
    {
        /// The GameObject
        public GameObject gameObject;

        /// The desired position
        public Vector3 position;

        /// The desired rotation
        public Quaternion rotation;
    }
}
