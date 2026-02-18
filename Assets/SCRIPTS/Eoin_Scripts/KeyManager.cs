using UnityEngine;
using UnityEngine.Events;

public class KeyManager : MonoBehaviour
{
    public bool yellowKey;
    public bool pinkKey;
    public bool blueKey;
    public bool shovel;
    public DoorScript yellowDoor;
    public DoorScript pinkDoor;
    public DoorScript blueDoor;
    public KeyFragmentGet keyFragmnetGet;
    public float fragmnetCount;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fragmnetCount == 3f)
        {
            blueKey = true;
        }
    }
}
