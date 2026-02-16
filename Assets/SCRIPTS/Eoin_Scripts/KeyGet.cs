using UnityEngine;

public class KeyGet : MonoBehaviour
{
    
    public KeyManager keyManager;

    public GameObject yellowKeyUI; // Assign the UI element in the Inspector

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

            // Show the UI element
            if (yellowKeyUI != null)
            {
                yellowKeyUI.SetActive(true);
            }

            Destroy(gameObject);
        }
    }
}
