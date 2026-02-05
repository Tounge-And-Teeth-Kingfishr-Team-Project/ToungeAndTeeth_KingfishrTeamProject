using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool doorOpen;
    public KeyManager keyManager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen == true)
        {
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && keyManager.yellowKey == true)
        {
            doorOpen = true;
            keyManager.yellowKey = false;
            transform.Rotate(0, -90, 0);
            
        }

        if (collision.gameObject.CompareTag("Player") && keyManager.blueKey == true)
        {
            doorOpen = true;
            keyManager.blueKey = false;
            transform.Rotate(0, -90, 0);
        }

        if (collision.gameObject.CompareTag("Player") && keyManager.pinkKey == true)
        {
            doorOpen = true;
            keyManager.pinkKey = false;
            transform.Rotate(0, -90, 0);
        }
    }
}
