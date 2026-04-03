using System.Collections;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public float dialougeTime;
    public GameObject dialogue;
    private BoxCollider collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        dialogue.SetActive(false);
    }

    IEnumerator TriggeredDialogue()
    {
        collider.enabled = false;
        dialogue.SetActive(true);
        yield return new WaitForSeconds(dialougeTime);
        dialogue.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>() != null)
        {
            StartCoroutine(TriggeredDialogue());
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
}
