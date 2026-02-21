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

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && keyManager.yellowKey)
        {
            OpenDoor(-90);
            keyManager.yellowKey = false;
        }

        if (other.CompareTag("Player") && keyManager.blueKey)
        {
            OpenDoor(-90);
            keyManager.blueKey = false;
            keyManager.fragmnetCount = 0;
        }

        if (other.CompareTag("Player") && keyManager.pinkKey)
        {
            OpenDoor(90);
            keyManager.pinkKey = false;
        }
    }

    void OpenDoor(float rotation)
    {
        if (!doorOpen)
        {
            doorOpen = true;
            transform.Rotate(0, rotation, 0);
        }
    }
}

