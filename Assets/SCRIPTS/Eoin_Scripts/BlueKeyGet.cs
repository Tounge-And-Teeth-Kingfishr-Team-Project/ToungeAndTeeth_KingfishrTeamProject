using UnityEngine;

public class BlueKeyGet : MonoBehaviour
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
            keyManager.blueKey = true;
            Destroy(gameObject);
        }
    }
}
