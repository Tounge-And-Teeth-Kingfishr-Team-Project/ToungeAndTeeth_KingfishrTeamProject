using UnityEngine;

public class InitiateDialogue : MonoBehaviour
{
    private PlayerMovement playerMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<TalkToFireplaceMan>() != null)
        {
            other.gameObject.GetComponent<TalkToFireplaceMan>().canTalk = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<TalkToFireplaceMan>() != null)
        {
            if (other.gameObject.GetComponent<TalkToFireplaceMan>().isTalking)
            {
                playerMovement.enabled = false;
            }
            else
            {
                playerMovement.enabled = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<TalkToFireplaceMan>() != null)
        {
            other.gameObject.GetComponent<TalkToFireplaceMan>().canTalk = false;
        }
    }
}
