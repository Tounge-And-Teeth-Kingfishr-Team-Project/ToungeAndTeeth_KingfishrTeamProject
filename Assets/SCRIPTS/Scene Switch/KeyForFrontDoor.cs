using UnityEngine;

public class KeyForFrontDoor : MonoBehaviour
{
    // The door object you want to appear/enable
    public GameObject frontDoorWORKING;
    public GameObject frontDoorFAKE;

    private void OnTriggerEnter(Collider other)
    {
        // Only trigger if the Player hits the object
        if (other.CompareTag("Player"))
        {
            //Dissabled the door
            if (frontDoorFAKE != null)
            {
                frontDoorFAKE.SetActive(false);
            }

            //Enable the door
            if (frontDoorWORKING != null)
            {
                frontDoorWORKING.SetActive(true);
            }

            // Delete this key object
            Destroy(gameObject);
        }
    }
}
