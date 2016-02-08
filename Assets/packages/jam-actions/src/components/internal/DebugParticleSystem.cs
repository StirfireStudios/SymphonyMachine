using UnityEngine;

public class DebugParticleSystem : MonoBehaviour
{
    public bool restart = false;

    public void Update()
    {
        if (restart)
        {
            var ps = gameObject.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                //var emitter = ps.emission;
                ps.Stop();
                ps.Clear();
                //ps.time = 0f;
                //emitter.enabled = true;
                //ps.Simulate(0f, true, true);
                ps.Play();
            }
            restart = false;
        }
    }
}
