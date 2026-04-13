using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            sound.Play();
            Debug.Log("I played the sound");
            Destroy(this);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}
