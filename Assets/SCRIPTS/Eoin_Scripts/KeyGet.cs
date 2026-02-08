using UnityEngine;

public class KeyGet : MonoBehaviour
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
        if(other.gameObject.CompareTag("Player") && keyManager.yellowKey != true)
        {
            keyManager.yellowKey = true;
            Destroy(gameObject);
        }
    }
}
