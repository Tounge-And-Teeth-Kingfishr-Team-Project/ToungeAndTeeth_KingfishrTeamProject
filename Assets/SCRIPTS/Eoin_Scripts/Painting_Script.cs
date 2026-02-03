using UnityEngine;

public class Painting_Script : MonoBehaviour
{
    public Rigidbody rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
        }
    }

}
