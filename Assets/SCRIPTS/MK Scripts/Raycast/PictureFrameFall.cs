using UnityEngine;

public class PictureFrameFall : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject yellowKey;
    private BoxCollider theCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        theCollider = rb.GetComponent<BoxCollider>();
    }
    public void Fall()
    {
        rb.isKinematic = false;
        theCollider.enabled = false;
        rb.AddForce(1f, 0, 5f, ForceMode.Impulse);
        theCollider.enabled = true;
        yellowKey.SetActive(true);
    }
}
