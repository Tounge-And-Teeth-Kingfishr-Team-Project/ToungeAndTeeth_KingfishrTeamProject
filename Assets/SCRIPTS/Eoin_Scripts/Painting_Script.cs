using UnityEngine;

public class Painting_Script : Interactable
{
    public Rigidbody rb;
    public GameObject yellowKey;   // Assign in inspector
    public GameObject SmileyFace;  // Object to hide when painting "falls"

    void Start()
    {
        rb.isKinematic = true;           // Painting starts static
        if (yellowKey != null)
            yellowKey.SetActive(false); // Hide key at start
    }

    // This replaces collision detection with E-to-interact
    protected override void Interact(GameObject player)
    {
        // Let the painting "fall"
        if (rb != null)
            rb.isKinematic = false;

        // Reveal the key
        if (yellowKey != null)
            yellowKey.SetActive(true);

        // Hide the specified object (like SmileyFace)
        if (SmileyFace != null)
            SmileyFace.SetActive(false);

        // Hide the interaction prompt
        ShowPrompt(false);

        Debug.Log("Painting interacted, key revealed!");
    }
}
