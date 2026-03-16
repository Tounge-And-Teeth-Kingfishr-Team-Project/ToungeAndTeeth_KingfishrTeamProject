using UnityEngine;
using UnityEngine.Playables;

public class PlayEffect : MonoBehaviour
{
    public PlayableDirector[] effects;
    public AudioSource[] sounds;
    public ParticleSystem[] particleSystems;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            if (effects != null)
            {
                for (int i = 0; i < effects.Length; i++)
                {
                    effects[i].Play();
                }
            }
            if (sounds != null)
            {
                for (int i = 0; i < sounds.Length; i++)
                {
                    sounds[i].Play();
                }
            }
            if (particleSystems != null)
            {
                for (int i = 0; i < particleSystems.Length; i++)
                {
                    particleSystems[i].Play();
                }
            }
            Destroy(gameObject);
        }
    }
}
