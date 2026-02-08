using UnityEngine;

public class PinkKeyGet : MonoBehaviour
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
        if(other.gameObject.CompareTag("Player") && keyManager.pinkKey != true)
        {
            keyManager.pinkKey = true;
            Destroy(gameObject);
        }
    }
}
