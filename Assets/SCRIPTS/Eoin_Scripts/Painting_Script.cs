using UnityEngine;

public class Painting_Script : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject yellowKey;   // Assign in inspector
    public GameObject SmileyFace;  // Assign the GameObject you want to hide when painting falls

    void Start()
    {
        rb.isKinematic = true;
        yellowKey.SetActive(false);  // Hide at start
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

            // Show the key when painting falls
            if (yellowKey != null)
            {
                yellowKey.SetActive(true);
            }

            // Turn off the specified GameObject
            if (SmileyFace != null)
            {
                SmileyFace.SetActive(false);
            }
        }
    }

}
