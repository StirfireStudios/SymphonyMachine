using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Jam.Utils.Layout
{
    public class LinearLayout : ILayout
    {
        /// The origin
        public Vector3 origin;

        /// The rotation for the plane
        public Quaternion rotation;

        /// Up vector
        public Vector3 up;

        /// Left vector
        public Vector3 left;

        /// Forward vector
        public Vector3 forward;

        /// The width of the layout
        public float width;

        /// The height of the layout
        public float height;

        /// The vertical offset
        public float upOffset;

        public LinearLayout(GameObject alignToTarget, float offset, float width, float height)
        {
            origin = alignToTarget.transform.position;
            var renderer = alignToTarget.GetComponent<Renderer>();
            up = alignToTarget.transform.forward.normalized;
            upOffset = offset;
            left = -alignToTarget.transform.right.normalized;
            this.height = height;
            this.width = width;
            forward = Vector3.Cross(up, left);

            // Align to plane
            rotation = alignToTarget.transform.rotation;
            rotation *= Quaternion.Euler(up * 90f);
        }

        /// Yield a set of locations and orientations for each target
        public IEnumerable<LayoutObject> Layout(IEnumerable<GameObject> target)
        {
            var count = target.Count();
            var offset_y = -height / 2f * up + upOffset * up;
            var origin_x = -width / 2f * left;
            var interval_x = width / (count - 1) * left;  // Number of gaps, not objects
            var offset_z = forward * 0.1f;
            var offset = 0;
            foreach (var gp in target)
            {
                var pos_x = origin_x + offset * interval_x;
                var pos = this.origin + pos_x + offset_y + offset_z;
                offset += 1;
                yield return new LayoutObject
                {
                    gameObject = gp,
                    rotation = rotation,
                    position = pos
                };
            }
        }
    }
}
