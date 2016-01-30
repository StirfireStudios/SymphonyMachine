using UnityEngine;
using System.Collections;

public class AmbienceController : MonoBehaviour
{

    public AudioSource channel1;
    public AudioSource channel2;

    IEnumerator activeFade;

    public float fadeDuration = 5.0f;

    bool playInFirst = true;

    public void PlaySound(AudioClip newSound)
    {
        AudioSource activeChannel = playInFirst ? channel1 : channel2;
        AudioSource oldChannel = playInFirst ? channel2 : channel1;

        activeChannel.clip = newSound;

        if (activeFade != null)
            StopCoroutine(activeFade);

        activeFade = CrossFade(activeChannel, oldChannel);

        StartCoroutine(activeFade);

        playInFirst = !playInFirst;
    }

    IEnumerator CrossFade(AudioSource active, AudioSource old)
    {
        active.volume = 0;

        float t = 0;

        bool lerping = true;

        active.Play();

        while (lerping)
        {

            active.volume = t;
            old.volume = 1 - t;
            t += Time.deltaTime / fadeDuration;

            if (t >= 1)
                lerping = false;

            yield return null;
        }

        old.Stop();
    }
}
