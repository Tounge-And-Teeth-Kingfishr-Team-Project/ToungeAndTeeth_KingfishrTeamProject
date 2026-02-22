using UnityEngine;
using UnityEngine.InputSystem;

public class GlobeScript : Interactable
{
    public Material unlitMat;
    public Material litMat;
    public bool correct;
    public float rotatePoint;

    void Start()
    {
        GetComponent<Renderer>().material = unlitMat; 
        correct = false; 
        rotatePoint = 0f; 
        transform.Rotate(0f, 0f, 0f);
    }

    protected override void Update()
    {
        base.Update(); // keeps E-interact prompt working

        //changes the colour to blue when the puzzle is solved
        if (correct == true) 
        {
            GetComponent<Renderer>().material = litMat;
        } 
        //resets the globe's rotation after five turns
        if (rotatePoint >= 5f) 
        { 
            rotatePoint = 0f;
            correct = false; 
            transform.Rotate(0f, 225f, 0f); 
        }
    }

    protected override void Interact(GameObject player)
    {
        if (!correct)
        {
            //turns the globe when the player touches it
                rotatePoint++;
                transform.Rotate(0f, -45f, 0f); 
                Debug.Log("Globe Rotated");
        }

        // Hide prompt after interaction
        //ShowPrompt(false);
    }
}
