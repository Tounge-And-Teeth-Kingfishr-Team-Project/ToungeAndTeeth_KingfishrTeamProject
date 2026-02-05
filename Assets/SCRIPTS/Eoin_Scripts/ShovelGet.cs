using UnityEngine;

public class ShovelGet : MonoBehaviour
{
    public KeyManager keyManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            keyManager.shovel = true;
            Destroy(gameObject);
        }
    }
}
