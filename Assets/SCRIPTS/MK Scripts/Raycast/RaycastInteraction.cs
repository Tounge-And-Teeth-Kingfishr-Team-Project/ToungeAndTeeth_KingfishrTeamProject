using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    public MK_KeyManager keyManager;
    public float maxDistance = 100;
    public LayerMask layersToHit;
    public GameObject interactUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        interactUI.SetActive(false);
        CheckForInteract();
    }
    void CheckForInteract()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layersToHit))
        {
            if (hit.collider.gameObject.layer != 8)
            {
                interactUI.transform.position = hit.transform.position;
                interactUI.SetActive(true);
            }

            Debug.Log(hit.collider.gameObject.name);

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject theHit = hit.collider.gameObject;
                if (theHit.layer == 7)      //7 is for keys (and shovel)
                {
                    theHit.GetComponent<Collectable_Manager>().IWasCollected();
                    theHit.SetActive(false);
                }
                if (theHit.layer == 8)      //8 is for doors (and rubble)
                {
                    theHit.GetComponent<Doors_Manager>().UnlockDoor();
                }
            }
        }
        else
        {
            interactUI.SetActive(false);
        }
    }
}
