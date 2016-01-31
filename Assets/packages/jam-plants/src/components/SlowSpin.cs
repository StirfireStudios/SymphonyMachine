using UnityEngine;
namespace Jam.Plants
{
    [AddComponentMenu("Jam/Plants/SlowSpin")]
    public class SlowSpin : MonoBehaviour
    {
        public Vector3 rotationAxis = new Vector3(0f, 1f, 0f);

        public float speed = 10f;

        public void Update()
        {
            gameObject.transform.rotation *= Quaternion.Euler(rotationAxis * speed * Time.deltaTime);
        }
    }
}
