using UnityEngine;

public class KeyFragmentGet : MonoBehaviour
{
    public KeyManager keyManager;
    public float fragmnetCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fragmnetCount ++;
            Destroy(gameObject);
        }

    }
}
