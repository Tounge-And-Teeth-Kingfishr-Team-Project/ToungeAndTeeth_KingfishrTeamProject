using UnityEngine;

public class RaycastInteraction : MonoBehaviour
{
    public PlayerMovement player;
    public FlashlightController flashlightController;
    public MK_KeyManager keyManager;
    public MirrorShardsPickup shardManager;
    public float maxDistance = 100;
    public LayerMask layersToHit;
    public GameObject interactUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        player = transform.parent.GetComponent<PlayerMovement>();
        flashlightController = transform.parent.GetComponent<FlashlightController>();
        if (interactUI != null) interactUI.SetActive(false);
    }
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
            if (interactUI != null)
            {
                if (hit.collider.gameObject.layer != 8 && hit.collider.gameObject.layer != 15)
                {
                    interactUI.transform.position = hit.transform.position;
                }
                else
                {
                    interactUI.transform.position = hit.collider.gameObject.transform.Find("UI Here").position;
                }
                interactUI.SetActive(true);
            }


            //THIS IS ALL THE INTERACTIONS WITH EVERY ITEM IN THE GAME
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
                if (theHit.layer == 12)     //12 is for text notes
                {
                    theHit.GetComponent<NoteRead>().ShowNote();
                    player.enabled = !player.enabled;
                }
                if (theHit.layer == 13)     //13 is for the UV light
                {
                    flashlightController.enabled = true;
                    Destroy(theHit.gameObject);
                }
                if (theHit.layer == 14)     //14 is for mirror shards
                {
                    shardManager.number++;
                    theHit.GetComponent<MirrorShardID>().shardCollected = true;
                    Destroy(theHit.gameObject);
                }
                if (theHit.layer == 15)     //15 is for the Fireplace Man
                {
                    theHit.GetComponent<TalkToFireplaceMan>().StartDialogue();
                }
                if (theHit.layer == 16)     //16 is for the broken mirror for the shards
                {
                    theHit.GetComponent<MirrorShardPlace>().Place();
                }
                if (theHit.layer == 17)     //17 is for the entrance door
                {
                    theHit.GetComponent<EntranceDoor>().OpenDoor();
                }
                Debug.Log(hit.collider.gameObject.name);
            }
        }
        else
        {
            if (interactUI != null)
            {
                interactUI.SetActive(false);
            }
        }
    }
}
