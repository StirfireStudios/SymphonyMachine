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

        /// border size
        public float borderSize;

        // number of lines
        public float lines;

        public float lineOffset;

        public LinearLayout(GameObject alignToTarget, float borderSize, float lines, float lineOffset)
        {
            origin = alignToTarget.transform.position;
            up = -alignToTarget.transform.up;
            left = alignToTarget.transform.right.normalized;
            this.borderSize = borderSize;
            this.height = alignToTarget.transform.lossyScale.y;
            this.width = alignToTarget.transform.lossyScale.x;
            this.lines = lines;
            this.lineOffset = -2 + lineOffset;
            forward = Vector3.Cross(up, left);

            // Align to plane
            // HAX! Screw the plane, align to this vector
            rotation = alignToTarget.transform.rotation;
        }

        /// Yield a set of locations and orientations for each target
        public IEnumerable<LayoutObject> Layout(IEnumerable<GameObject> target)
        {
            var count = target.Count();
            var single_height = height / lines * up;
            var single_width = width / count * left;
            var interval_x = 2f * borderSize * left;
            var size = new Vector3(width / count - borderSize / 2.0f, height / lines - borderSize / 2.0f, 1.0f);
            var offset = -2;
            foreach (var gp in target)
            {
                var pos_x = offset * single_width + single_width / 2f;
                var pos_y = lineOffset * single_height + single_height / 2f;
                var pos = origin + pos_x + pos_y;
                offset += 1;
                yield return new LayoutObject
                {
                    gameObject = gp,
                    rotation = rotation,
                    position = pos,
                    scale = size
                };
            }
        }

        private Vector3 getObjectSize(GameObject target)
        {
            Renderer renderer = target.GetComponent<Renderer>();
            if (renderer == null)
            {
                return new Vector3();
            }
            return Vector3.Scale(renderer.bounds.size, target.transform.lossyScale);
        }

        private Vector3 calculateScaleFactor(GameObject target, Vector3 size)
        {
            var targetSize = getObjectSize(target);
            var scaleFactor = new Vector3();
            scaleFactor.x = 0.2f;
            scaleFactor.y = 0.2f;
            scaleFactor.z = 0.2f;

            return scaleFactor;
        }
    }
}
