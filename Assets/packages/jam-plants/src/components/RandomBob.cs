using UnityEngine;
using Jam.Utils;

namespace Jam.Plants
{
    [AddComponentMenu("Jam/Plants/RandomBob")]
    public class RandomBob : MonoBehaviour
    {
        public Vector3 bobDirection = new Vector3(0f, 1f, 0f);

        public bool inBob = false;

        public float bobMin = 0f;
        public float bobMax = 1f;
        public float bobOffset = 0f;
        private float bobAmount;

        public float duration = 2.5f;
        private float elapsed;

        public float bobIntervalVariation = 2f;
        public float baseBobInterval = 1f;

        private float timeSinceLastBob = 0f;

        public void Update()
        {
            if (inBob)
            {
                UpdateBob(Time.deltaTime);
            }
            else
            {
                timeSinceLastBob += Time.deltaTime;
                var interval = baseBobInterval + Jam.Utils.Random.Between(0f, bobIntervalVariation);
                if (timeSinceLastBob > interval)
                { StartBob(); }
            }
        }

        public void StartBob()
        {
            elapsed = 0f;
            bobAmount = Jam.Utils.Random.Between(bobMin, bobMax);
            inBob = true;
        }

        public void UpdateBob(float dt)
        {
            elapsed += dt;
            var amount = elapsed / duration;
            var value = Mathf.Sin(amount * 2f * Mathf.PI);
            value = value * value * bobAmount;
            var offset = bobDirection * bobOffset + bobDirection * value;
            gameObject.transform.localPosition = offset;
            if (amount >= 1f)
            {
                inBob = false;
                timeSinceLastBob = 0f;
            }
        }
    }
}
