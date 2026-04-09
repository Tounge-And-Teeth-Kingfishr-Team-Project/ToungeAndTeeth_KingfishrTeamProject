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


            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject theHit = hit.collider.gameObject;
                if (theHit.layer == 7)      //7 is for keys (and shovel)
                {
                    theHit.transform.parent.GetComponent<Collectable_Manager>().IWasCollected();
                }
                if (theHit.layer == 8)      //8 is for doors (and rubble)
                {
                    theHit.GetComponent<Doors_Manager>().UnlockDoor();
                }
                if (theHit.layer == 9)      //9 is for picture frames
                {
                    if (theHit.GetComponent<PictureFrameFall>() != null)
                    {
                        theHit.GetComponent<PictureFrameFall>().Fall();
                    }
                }
                if (theHit.layer == 10)     //10 is for the da vinci box
                {
                    theHit.GetComponent<CodePuzzle>().Unlock();
                }
                if (theHit.layer == 11)     //11 is for globes
                {
                    theHit.GetComponent<MoonInteract>().RotateMoon();
                }
                Debug.Log(hit.collider.gameObject.name);
            }
        }
        else
        {
            interactUI.SetActive(false);
        }
    }
}
