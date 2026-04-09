using UnityEngine;

public class PictureFrameFall : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject yellowKey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Fall()
    {
        rb.isKinematic = false;
        yellowKey.SetActive(true);
    }
}
