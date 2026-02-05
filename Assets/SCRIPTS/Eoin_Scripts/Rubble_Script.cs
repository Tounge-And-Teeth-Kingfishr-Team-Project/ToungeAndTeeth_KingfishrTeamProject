using UnityEngine;

public class Rubble_Script : MonoBehaviour
{
    public KeyManager keyManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && keyManager.shovel == true)
        {
            Destroy(gameObject);
        }
    }
}
