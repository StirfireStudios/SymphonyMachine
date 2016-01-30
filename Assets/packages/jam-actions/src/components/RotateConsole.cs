using UnityEngine;

namespace Jam.Actions
{
    /// Rotate the console target by the specified amount
    [AddComponentMenu("Jam/Actions/Rotate Console")]
    public class RotateConsole : ActionBase
    {
        [Tooltip("The amount to rotate, in degrees")]
        public float amount = 90f;

        [Tooltip("Duration of rotation")]
        public float duration = 1f;

        [Tooltip("The specific object instance to apply the transform to")]
        public GameObject target;

        [Tooltip("The normal to rotate around")]
        public Vector3 up = new Vector3(0f, 1f, 0f);

        private Quaternion originalRotation;
        private Quaternion targetRotation;
        private float elapsed;

        protected override void Execute()
        {
            originalRotation = target.transform.rotation;
            targetRotation = target.transform.rotation;
            targetRotation *= Quaternion.Euler(up * amount);
            elapsed = 0f;
            if (duration <= 0f)
            { duration = 0.1f; }
        }

        protected override void Step(float dt)
        {
            elapsed += dt;
            var offset = elapsed / duration;
            if (offset > 1f) { offset = 1f; }
            target.transform.rotation = Quaternion.Slerp(originalRotation, targetRotation, offset);
            if (offset == 1f)
            {
                Complete();
            }
        }
    }
}
