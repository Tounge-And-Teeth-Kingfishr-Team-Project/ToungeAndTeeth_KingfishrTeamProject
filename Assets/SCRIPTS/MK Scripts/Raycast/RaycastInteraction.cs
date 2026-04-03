using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    public MK_KeyManager keyManager;
    public float maxDistance = 100;
    public LayerMask layersToHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        CheckForInteract();
    }
    void CheckForInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layersToHit))
        {
            Debug.Log(hit.collider.gameObject.name);

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject theHit = hit.collider.gameObject;
                if (theHit.layer == 7)      //7 is for keys
                {
                    theHit.GetComponent<Collectable_Manager>().IWasCollected();
                    theHit.SetActive(false);
                }
                if (theHit.layer == 8)
                {
                    theHit.GetComponent<Doors_Manager>().UnlockDoor();
                }
            }
        }
    }
}
